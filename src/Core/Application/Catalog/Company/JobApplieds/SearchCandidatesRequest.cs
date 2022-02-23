using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public class SearchCandidatesRequest : PaginationFilter, IRequest<PaginationResponse<JobAppliedDto>>
{
    public Guid? RecruitmentId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? CurrentPositionId { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? JobNameId { get; set; }

    public Guid? DegreeId { get; set; }
    public Guid? ExperienceId { get; set; }
    public Guid? JobTypeId { get; set; }
}

public class SearchCandidatesRequestHandler : IRequestHandler<SearchCandidatesRequest, PaginationResponse<JobAppliedDto>>
{
    private readonly IReadRepository<JobApplied> _repository;
    private readonly ICurrentUser _currentUser;
    private readonly IUserService _userService;

    public SearchCandidatesRequestHandler(IReadRepository<JobApplied> repository, ICurrentUser currentUser, IUserService userService) => (_repository, _currentUser, _userService) = (repository, currentUser, userService);

    public async Task<PaginationResponse<JobAppliedDto>> Handle(SearchCandidatesRequest request, CancellationToken cancellationToken)
    {
        var spec = new CandidatesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        foreach (var item in list)
        {
            if (item != null && !string.IsNullOrWhiteSpace(item.UserName))
            {
                var tmp = await _userService.GetAsyncByUserName(item.UserName, cancellationToken);
                item.JobApplication.FullName = tmp.FullName;
                item.JobApplication.ImageUrl = tmp.ImageUrl;
                item.JobApplication.PhoneNumber = tmp.PhoneNumber;
            }
        }

        return new PaginationResponse<JobAppliedDto>(list, count, request.PageNumber, request.PageSize);
    }
}