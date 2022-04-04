namespace TD.CitizenAPI.Application.Catalog.TourGuides;

public class SearchTourGuidesRequest : PaginationFilter, IRequest<PaginationResponse<TourGuideDto>>
{
}

public class MarketCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<TourGuide, TourGuideDto>
{
    public MarketCategoriesBySearchRequestSpec(SearchTourGuidesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.FullName, !request.HasOrderBy());
}

public class SearchMarketCategoriesRequestHandler : IRequestHandler<SearchTourGuidesRequest, PaginationResponse<TourGuideDto>>
{
    private readonly IReadRepository<TourGuide> _repository;

    public SearchMarketCategoriesRequestHandler(IReadRepository<TourGuide> repository) => _repository = repository;

    public async Task<PaginationResponse<TourGuideDto>> Handle(SearchTourGuidesRequest request, CancellationToken cancellationToken)
    {
        var spec = new MarketCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<TourGuideDto>(list, count, request.PageNumber, request.PageSize);
    }
}