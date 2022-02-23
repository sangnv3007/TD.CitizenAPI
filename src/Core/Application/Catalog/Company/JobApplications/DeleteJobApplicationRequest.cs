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
    private readonly ICurrentUser _currentUser;

    private readonly IStringLocalizer<DeleteJobApplicationRequestHandler> _localizer;

    public DeleteJobApplicationRequestHandler(IRepositoryWithEvents<JobApplication> repository, ICurrentUser currentUser, IStringLocalizer<DeleteJobApplicationRequestHandler> localizer) =>
        (_repository, _currentUser, _localizer) = (repository, currentUser, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobApplicationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobApplication.notfound"]);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (!_currentUser.GetUserName().Equals(item.UserName))
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        {
            throw new NotFoundException(_localizer["Ban khong co quyen xoa"]);
        }

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}