namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public class DeleteJobAppliedRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteJobAppliedRequest(Guid id) => Id = id;
}

public class DeleteJobAppliedRequestHandler : IRequestHandler<DeleteJobAppliedRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobApplied> _repository;
    private readonly IStringLocalizer<DeleteJobAppliedRequestHandler> _localizer;

    public DeleteJobAppliedRequestHandler(IRepositoryWithEvents<JobApplied> repository, IStringLocalizer<DeleteJobAppliedRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobAppliedRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobApplied.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}