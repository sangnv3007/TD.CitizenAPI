namespace TD.CitizenAPI.Application.Catalog.ProjectInvestInformations;

public class DeleteProjectInvestInformationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteProjectInvestInformationRequest(Guid id) => Id = id;
}

public class DeleteProjectInvestInformationRequestHandler : IRequestHandler<DeleteProjectInvestInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestInformation> _repository;
    private readonly IStringLocalizer<DeleteProjectInvestInformationRequestHandler> _localizer;

    public DeleteProjectInvestInformationRequestHandler(IRepositoryWithEvents<ProjectInvestInformation> repository, IStringLocalizer<DeleteProjectInvestInformationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteProjectInvestInformationRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["ProjectInvestInformation.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}