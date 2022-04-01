namespace TD.CitizenAPI.Application.Catalog.ProjectInvestInformations;

public class GetProjectInvestInformationRequest : IRequest<Result<ProjectInvestInformationDetailsDto>>
{
    public Guid Id { get; set; }

    public GetProjectInvestInformationRequest(Guid id) => Id = id;
}

public class ProjectInvestInformationByIdSpec : Specification<ProjectInvestInformation, ProjectInvestInformationDetailsDto>, ISingleResultSpecification
{
    public ProjectInvestInformationByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
       .Include(p => p.ProjectInvestCategory)
        .Include(p => p.ProjectInvestForm)
        ;
}

public class GetProjectInvestInformationRequestHandler : IRequestHandler<GetProjectInvestInformationRequest, Result<ProjectInvestInformationDetailsDto>>
{
    private readonly IRepository<ProjectInvestInformation> _repository;
    private readonly IStringLocalizer<GetProjectInvestInformationRequestHandler> _localizer;

    public GetProjectInvestInformationRequestHandler(IRepository<ProjectInvestInformation> repository, IStringLocalizer<GetProjectInvestInformationRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<ProjectInvestInformationDetailsDto>> Handle(GetProjectInvestInformationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<ProjectInvestInformation, ProjectInvestInformationDetailsDto>)new ProjectInvestInformationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["ProjectInvestInformation.notfound"], request.Id));
        return Result<ProjectInvestInformationDetailsDto>.Success(item);

    }
}