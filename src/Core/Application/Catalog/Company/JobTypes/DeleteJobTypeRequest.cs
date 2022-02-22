namespace TD.CitizenAPI.Application.Catalog.JobTypes;

public class DeleteJobTypeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteJobTypeRequest(Guid id) => Id = id;
}

public class DeleteJobTypeRequestHandler : IRequestHandler<DeleteJobTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobType> _repository;
    private readonly IStringLocalizer<DeleteJobTypeRequestHandler> _localizer;

    public DeleteJobTypeRequestHandler(IRepositoryWithEvents<JobType> repository, IStringLocalizer<DeleteJobTypeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobTypeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobType.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}