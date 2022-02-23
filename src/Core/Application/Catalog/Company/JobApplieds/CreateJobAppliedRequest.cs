namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public partial class CreateJobAppliedRequest : IRequest<Result<Guid>>
{
    public Guid? JobApplicationId { get; set; }
    public Guid? RecruitmentId { get; set; }
}

public class CreateJobAppliedRequestValidator : CustomValidator<CreateJobAppliedRequest>
{
    public CreateJobAppliedRequestValidator(IReadRepository<JobApplied> repository, IStringLocalizer<CreateJobAppliedRequestValidator> localizer)
    {
        RuleFor(p => p.JobApplicationId).NotEmpty();
        RuleFor(p => p.RecruitmentId).NotEmpty();
    }
}

public class CreateJobAppliedRequestHandler : IRequestHandler<CreateJobAppliedRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobApplied> _repository;
    private readonly ICurrentUser _currentUser;

    public CreateJobAppliedRequestHandler(IRepositoryWithEvents<JobApplied> repository, ICurrentUser currentUser) => (_repository, _currentUser) = (repository, currentUser);

    public async Task<Result<Guid>> Handle(CreateJobAppliedRequest request, CancellationToken cancellationToken)
    {
        var item = new JobApplied(_currentUser.GetUserName(), request.JobApplicationId, request.RecruitmentId, 1);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}