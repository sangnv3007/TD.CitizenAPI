namespace TD.CitizenAPI.Application.Catalog.LawDatas;

public class SearchLawDatasRequest : PaginationFilter, IRequest<PaginationResponse<LawDataDto>>
{
}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<LawData, LawDataDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchLawDatasRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Title, !request.HasOrderBy());
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchLawDatasRequest, PaginationResponse<LawDataDto>>
{
    private readonly IReadRepository<LawData> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<LawData> repository) => _repository = repository;

    public async Task<PaginationResponse<LawDataDto>> Handle(SearchLawDatasRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<LawDataDto>(list, count, request.PageNumber, request.PageSize);
    }
}