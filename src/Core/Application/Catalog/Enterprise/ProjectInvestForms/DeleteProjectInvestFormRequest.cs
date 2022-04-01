namespace TD.CitizenAPI.Application.Catalog.ProjectInvestForms;

public class DeleteProjectInvestFormRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteProjectInvestFormRequest(Guid id) => Id = id;
}

public class DeleteProjectInvestFormRequestHandler : IRequestHandler<DeleteProjectInvestFormRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestForm> _repository;
    private readonly IStringLocalizer<DeleteProjectInvestFormRequestHandler> _localizer;

    public DeleteProjectInvestFormRequestHandler(IRepositoryWithEvents<ProjectInvestForm> repository, IStringLocalizer<DeleteProjectInvestFormRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteProjectInvestFormRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["ProjectInvestForm.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}