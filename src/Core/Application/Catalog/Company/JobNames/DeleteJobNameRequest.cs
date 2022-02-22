namespace TD.CitizenAPI.Application.Catalog.JobNames;

public class DeleteJobNameRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteJobNameRequest(Guid id) => Id = id;
}

public class DeleteJobNameRequestHandler : IRequestHandler<DeleteJobNameRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobName> _repository;
    private readonly IStringLocalizer<DeleteJobNameRequestHandler> _localizer;

    public DeleteJobNameRequestHandler(IRepositoryWithEvents<JobName> repository, IStringLocalizer<DeleteJobNameRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobNameRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobName.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}