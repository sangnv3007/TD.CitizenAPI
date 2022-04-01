namespace TD.CitizenAPI.Application.Catalog.ProjectInvestCategories;

public class SearchProjectInvestCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<ProjectInvestCategoryDto>>
{
}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<ProjectInvestCategory, ProjectInvestCategoryDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchProjectInvestCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchProjectInvestCategoriesRequest, PaginationResponse<ProjectInvestCategoryDto>>
{
    private readonly IReadRepository<ProjectInvestCategory> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<ProjectInvestCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<ProjectInvestCategoryDto>> Handle(SearchProjectInvestCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProjectInvestCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}