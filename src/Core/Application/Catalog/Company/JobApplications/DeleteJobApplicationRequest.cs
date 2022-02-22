namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class DeleteJobApplicationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteJobApplicationRequest(Guid id) => Id = id;
}

public class DeleteJobApplicationRequestHandler : IRequestHandler<DeleteJobApplicationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobApplication> _repository;
    private readonly IStringLocalizer<DeleteJobApplicationRequestHandler> _localizer;

    public DeleteJobApplicationRequestHandler(IRepositoryWithEvents<JobApplication> repository, IStringLocalizer<DeleteJobApplicationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobApplicationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobApplication.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}