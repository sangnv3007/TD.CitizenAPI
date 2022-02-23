using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class GetJobApplicationRequest : IRequest<Result<JobApplicationDetailsDto>>
{
    public Guid Id { get; set; }

    public GetJobApplicationRequest(Guid id) => Id = id;
}

public class JobApplicationByIdSpec : Specification<JobApplication, JobApplicationDetailsDto>, ISingleResultSpecification
{
    public JobApplicationByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.CurrentPosition)
        .Include(p => p.JobName)
        .Include(p => p.Position)
        .Include(p => p.Experience)
        .Include(p => p.Degree)
        .Include(p => p.JobType)
        ;
}

public class GetJobApplicationRequestHandler : IRequestHandler<GetJobApplicationRequest, Result<JobApplicationDetailsDto>>
{
    private readonly IRepository<JobApplication> _repository;
    private readonly IUserService _userService;

    private readonly IStringLocalizer<GetJobApplicationRequestHandler> _localizer;

    public GetJobApplicationRequestHandler(IRepository<JobApplication> repository, IUserService userService, IStringLocalizer<GetJobApplicationRequestHandler> localizer) => (_repository, _userService, _localizer) = (repository, userService, localizer);

    public async Task<Result<JobApplicationDetailsDto>> Handle(GetJobApplicationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<JobApplication, JobApplicationDetailsDto>)new JobApplicationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["JobApplication.notfound"], request.Id));

        item.User = await _userService.GetAsyncByUserName(item.UserName, cancellationToken);


        return Result<JobApplicationDetailsDto>.Success(item);

    }
}