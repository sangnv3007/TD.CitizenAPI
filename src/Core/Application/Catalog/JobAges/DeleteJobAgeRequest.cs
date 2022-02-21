namespace TD.CitizenAPI.Application.Catalog.JobAges;

public class DeleteJobAgeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteJobAgeRequest(Guid id) => Id = id;
}

public class DeleteJobAgeRequestHandler : IRequestHandler<DeleteJobAgeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobAge> _repository;
    private readonly IStringLocalizer<DeleteJobAgeRequestHandler> _localizer;

    public DeleteJobAgeRequestHandler(IRepositoryWithEvents<JobAge> repository, IStringLocalizer<DeleteJobAgeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobAgeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobAge.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}