namespace TD.CitizenAPI.Application.Catalog.TravelHandbooks;

public class SearchTravelHandbooksRequest : PaginationFilter, IRequest<PaginationResponse<TravelHandbookDto>>
{
}

public class TravelHandbooksBySearchRequestSpec : EntitiesByPaginationFilterSpec<TravelHandbook, TravelHandbookDto>
{
    public TravelHandbooksBySearchRequestSpec(SearchTravelHandbooksRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchTravelHandbooksRequestHandler : IRequestHandler<SearchTravelHandbooksRequest, PaginationResponse<TravelHandbookDto>>
{
    private readonly IReadRepository<TravelHandbook> _repository;

    public SearchTravelHandbooksRequestHandler(IReadRepository<TravelHandbook> repository) => _repository = repository;

    public async Task<PaginationResponse<TravelHandbookDto>> Handle(SearchTravelHandbooksRequest request, CancellationToken cancellationToken)
    {
        var spec = new TravelHandbooksBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<TravelHandbookDto>(list, count, request.PageNumber, request.PageSize);
    }
}