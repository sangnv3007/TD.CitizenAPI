namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public class DeleteJobAppliedRequest : IRequest<Result<Guid>>
{
    public Guid RecruitmentId { get; set; }

    public DeleteJobAppliedRequest(Guid id) => RecruitmentId = id;
}

public class JobAppliedByUserNameRecruitmentSpec : Specification<JobApplied>, ISingleResultSpecification
{
    public JobAppliedByUserNameRecruitmentSpec(string? userName, Guid recruitmentId) =>
        Query.Where(p => p.UserName == userName && p.RecruitmentId == recruitmentId);
}

public class DeleteJobAppliedRequestHandler : IRequestHandler<DeleteJobAppliedRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobApplied> _repository;
    private readonly IStringLocalizer<DeleteJobAppliedRequestHandler> _localizer;
    private readonly ICurrentUser _currentUser;


    public DeleteJobAppliedRequestHandler(IRepositoryWithEvents<JobApplied> repository, ICurrentUser currentUser, IStringLocalizer<DeleteJobAppliedRequestHandler> localizer) =>
        (_repository, _currentUser, _localizer) = (repository, currentUser, localizer);

    public async Task<Result<Guid>> Handle(DeleteJobAppliedRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
          new JobAppliedByUserNameRecruitmentSpec(_currentUser.GetUserName(), request.RecruitmentId), cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["JobSaved.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.RecruitmentId);
    }
}