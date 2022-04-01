namespace TD.CitizenAPI.Application.Catalog.LaborMarketInformations;

public class SearchLaborMarketInformationsRequest : PaginationFilter, IRequest<PaginationResponse<LaborMarketInformationDto>>
{
}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<LaborMarketInformation, LaborMarketInformationDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchLaborMarketInformationsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy());
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchLaborMarketInformationsRequest, PaginationResponse<LaborMarketInformationDto>>
{
    private readonly IReadRepository<LaborMarketInformation> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<LaborMarketInformation> repository) => _repository = repository;

    public async Task<PaginationResponse<LaborMarketInformationDto>> Handle(SearchLaborMarketInformationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<LaborMarketInformationDto>(list, count, request.PageNumber, request.PageSize);
    }
}