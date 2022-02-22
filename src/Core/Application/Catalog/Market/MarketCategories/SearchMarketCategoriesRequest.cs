namespace TD.CitizenAPI.Application.Catalog.MarketCategories;

public class SearchMarketCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<MarketCategoryDto>>
{
}

public class MarketCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<MarketCategory, MarketCategoryDto>
{
    public MarketCategoriesBySearchRequestSpec(SearchMarketCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchMarketCategoriesRequestHandler : IRequestHandler<SearchMarketCategoriesRequest, PaginationResponse<MarketCategoryDto>>
{
    private readonly IReadRepository<MarketCategory> _repository;

    public SearchMarketCategoriesRequestHandler(IReadRepository<MarketCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<MarketCategoryDto>> Handle(SearchMarketCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new MarketCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<MarketCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}