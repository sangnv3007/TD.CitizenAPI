namespace TD.CitizenAPI.Application.Catalog.ProjectInvestForms;

public class GetProjectInvestFormRequest : IRequest<Result<ProjectInvestFormDetailsDto>>
{
    public Guid Id { get; set; }

    public GetProjectInvestFormRequest(Guid id) => Id = id;
}

public class ProjectInvestFormByIdSpec : Specification<ProjectInvestForm, ProjectInvestFormDetailsDto>, ISingleResultSpecification
{
    public ProjectInvestFormByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetProjectInvestFormRequestHandler : IRequestHandler<GetProjectInvestFormRequest, Result<ProjectInvestFormDetailsDto>>
{
    private readonly IRepository<ProjectInvestForm> _repository;
    private readonly IStringLocalizer<GetProjectInvestFormRequestHandler> _localizer;

    public GetProjectInvestFormRequestHandler(IRepository<ProjectInvestForm> repository, IStringLocalizer<GetProjectInvestFormRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<ProjectInvestFormDetailsDto>> Handle(GetProjectInvestFormRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<ProjectInvestForm, ProjectInvestFormDetailsDto>)new ProjectInvestFormByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["ProjectInvestForm.notfound"], request.Id));
        return Result<ProjectInvestFormDetailsDto>.Success(item);

    }
}