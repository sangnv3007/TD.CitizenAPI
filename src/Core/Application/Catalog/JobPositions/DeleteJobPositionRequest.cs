namespace TD.CitizenAPI.Application.Catalog.JobPositions;

public class DeleteJobPositionRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteJobPositionRequest(Guid id) => Id = id;
}

public class DeleteJobPositionRequestHandler : IRequestHandler<DeleteJobPositionRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobPosition> _repository;
    private readonly IStringLocalizer<DeleteJobPositionRequestHandler> _localizer;

    public DeleteJobPositionRequestHandler(IRepositoryWithEvents<JobPosition> repository, IStringLocalizer<DeleteJobPositionRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobPositionRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobPosition.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}