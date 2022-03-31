namespace TD.CitizenAPI.Application.Catalog.AlertOrganizations;

public class SearchMarketCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<AlertOrganizationDto>>
{
}

public class MarketCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<AlertOrganization, AlertOrganizationDto>
{
    public MarketCategoriesBySearchRequestSpec(SearchMarketCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchMarketCategoriesRequestHandler : IRequestHandler<SearchMarketCategoriesRequest, PaginationResponse<AlertOrganizationDto>>
{
    private readonly IReadRepository<AlertOrganization> _repository;

    public SearchMarketCategoriesRequestHandler(IReadRepository<AlertOrganization> repository) => _repository = repository;

    public async Task<PaginationResponse<AlertOrganizationDto>> Handle(SearchMarketCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new MarketCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AlertOrganizationDto>(list, count, request.PageNumber, request.PageSize);
    }
}