namespace TD.CitizenAPI.Application.Catalog.ProjectInvestForms;

public class SearchProjectInvestFormsRequest : PaginationFilter, IRequest<PaginationResponse<ProjectInvestFormDto>>
{
}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<ProjectInvestForm, ProjectInvestFormDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchProjectInvestFormsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchProjectInvestFormsRequest, PaginationResponse<ProjectInvestFormDto>>
{
    private readonly IReadRepository<ProjectInvestForm> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<ProjectInvestForm> repository) => _repository = repository;

    public async Task<PaginationResponse<ProjectInvestFormDto>> Handle(SearchProjectInvestFormsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProjectInvestFormDto>(list, count, request.PageNumber, request.PageSize);
    }
}