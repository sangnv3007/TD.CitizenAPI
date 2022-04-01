namespace TD.CitizenAPI.Application.Catalog.ProjectInvestCategories;

public class GetProjectInvestCategoryRequest : IRequest<Result<ProjectInvestCategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetProjectInvestCategoryRequest(Guid id) => Id = id;
}

public class ProjectInvestCategoryByIdSpec : Specification<ProjectInvestCategory, ProjectInvestCategoryDetailsDto>, ISingleResultSpecification
{
    public ProjectInvestCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetProjectInvestCategoryRequestHandler : IRequestHandler<GetProjectInvestCategoryRequest, Result<ProjectInvestCategoryDetailsDto>>
{
    private readonly IRepository<ProjectInvestCategory> _repository;
    private readonly IStringLocalizer<GetProjectInvestCategoryRequestHandler> _localizer;

    public GetProjectInvestCategoryRequestHandler(IRepository<ProjectInvestCategory> repository, IStringLocalizer<GetProjectInvestCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<ProjectInvestCategoryDetailsDto>> Handle(GetProjectInvestCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<ProjectInvestCategory, ProjectInvestCategoryDetailsDto>)new ProjectInvestCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["ProjectInvestCategory.notfound"], request.Id));
        return Result<ProjectInvestCategoryDetailsDto>.Success(item);

    }
}