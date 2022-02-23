namespace TD.CitizenAPI.Application.Catalog.JobSaveds;

public class DeleteJobSavedRequest : IRequest<Result<Guid>>
{
    public Guid RecruitmentId { get; set; }

    public DeleteJobSavedRequest(Guid recruitmentId) => RecruitmentId = recruitmentId;
}

public class JobSavedByUserNameRecruitmentSpec : Specification<JobSaved>, ISingleResultSpecification
{
    public JobSavedByUserNameRecruitmentSpec(string? userName, Guid recruitmentId) =>
        Query.Where(p => p.UserName == userName && p.RecruitmentId == recruitmentId);
}
public class DeleteJobSavedRequestHandler : IRequestHandler<DeleteJobSavedRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobSaved> _repository;
    private readonly ICurrentUser _currentUser;
    private readonly IStringLocalizer<DeleteJobSavedRequestHandler> _localizer;

    public DeleteJobSavedRequestHandler(IRepositoryWithEvents<JobSaved> repository, ICurrentUser currentUser, IStringLocalizer<DeleteJobSavedRequestHandler> localizer) =>
        (_repository, _currentUser, _localizer) = (repository, currentUser, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobSavedRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
          new JobSavedByUserNameRecruitmentSpec(_currentUser.GetUserName(), request.RecruitmentId), cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobSaved.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.RecruitmentId);
    }
}