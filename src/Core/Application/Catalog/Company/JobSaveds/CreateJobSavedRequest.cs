namespace TD.CitizenAPI.Application.Catalog.JobSaveds;

public class CreateJobSavedRequest : IRequest<Result<Guid>>
{
    public Guid? RecruitmentId { get; set; }
}

public class CreateJobSavedRequestValidator : CustomValidator<CreateJobSavedRequest>
{
    public CreateJobSavedRequestValidator(IReadRepository<JobSaved> repository, IStringLocalizer<CreateJobSavedRequestValidator> localizer) =>
        RuleFor(p => p.RecruitmentId).NotEmpty();
       
}

public class CreateJobSavedRequestHandler : IRequestHandler<CreateJobSavedRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobSaved> _repository;
    private readonly ICurrentUser _currentUser;


    public CreateJobSavedRequestHandler(IRepositoryWithEvents<JobSaved> repository, ICurrentUser currentUser) => (_repository, _currentUser) = (repository, currentUser);

    public async Task<Result<Guid>> Handle(CreateJobSavedRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(new JobSavedByUserNameRecruitmentIdSpec(_currentUser.GetUserName(), (Guid)request.RecruitmentId), cancellationToken);
        if (item == null)
        {
             item = new JobSaved(_currentUser.GetUserName(), request.RecruitmentId);
             await _repository.AddAsync(item, cancellationToken);
        }
      
        return Result<Guid>.Success(item.Id);
    }
}