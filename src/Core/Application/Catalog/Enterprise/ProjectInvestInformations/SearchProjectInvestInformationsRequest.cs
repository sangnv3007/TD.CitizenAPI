namespace TD.CitizenAPI.Application.Catalog.ProjectInvestInformations;

public class SearchProjectInvestInformationsRequest : PaginationFilter, IRequest<PaginationResponse<ProjectInvestInformationDto>>
{
    public Guid? ProjectInvestCategoryId { get; set; }
    public Guid? ProjectInvestFormId { get; set; }

}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<ProjectInvestInformation, ProjectInvestInformationDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchProjectInvestInformationsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy())
        .Include(p => p.ProjectInvestCategory)
        .Include(p => p.ProjectInvestForm)
        .Where(p => p.ProjectInvestCategoryId.Equals(request.ProjectInvestCategoryId!.Value), request.ProjectInvestCategoryId.HasValue)
        .Where(p => p.ProjectInvestFormId.Equals(request.ProjectInvestFormId!.Value), request.ProjectInvestFormId.HasValue)
        ;
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchProjectInvestInformationsRequest, PaginationResponse<ProjectInvestInformationDto>>
{
    private readonly IReadRepository<ProjectInvestInformation> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<ProjectInvestInformation> repository) => _repository = repository;

    public async Task<PaginationResponse<ProjectInvestInformationDto>> Handle(SearchProjectInvestInformationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProjectInvestInformationDto>(list, count, request.PageNumber, request.PageSize);
    }
}