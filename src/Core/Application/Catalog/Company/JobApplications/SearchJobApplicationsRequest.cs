using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class SearchJobApplicationsRequest : PaginationFilter, IRequest<PaginationResponse<JobApplicationDto>>
{
    public string? UserName { get; set; }
    public Guid? CurrentPositionId { get; set; }
    //Vi tri mong muon
    public Guid? PositionId { get; set; }
    public Guid? JobNameId { get; set; }

    //Trinh do hoc van
    public Guid? DegreeId { get; set; }
    //Tong so nam Kinh nghiem
    public Guid? ExperienceId { get; set; }

    //Mong muon muc luong toi thieu
    public int? MinExpectedSalaryFrom { get; set; }
    public int? MinExpectedSalaryTo { get; set; }
    //Dia diem lam viec
    
    //Hinh thuc lam viec
    public Guid? JobTypeId { get; set; }
}
public class SearchJobApplicationsRequestHandler : IRequestHandler<SearchJobApplicationsRequest, PaginationResponse<JobApplicationDto>>
{
    private readonly IReadRepository<JobApplication> _repository;
    private readonly IUserService _userService;

    public SearchJobApplicationsRequestHandler(IReadRepository<JobApplication> repository, IUserService userService) => (_repository, _userService) = (repository, userService);

    public async Task<PaginationResponse<JobApplicationDto>> Handle(SearchJobApplicationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobApplicationsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        foreach (var item in list)
        {
            if (item != null && !string.IsNullOrWhiteSpace(item.UserName))
            {
                var tmp = await _userService.GetAsyncByUserName(item.UserName, cancellationToken);
                item.FullName = tmp.FullName;
                item.ImageUrl = tmp.ImageUrl;
                item.PhoneNumber = tmp.PhoneNumber;
            }
        }

        return new PaginationResponse<JobApplicationDto>(list, count, request.PageNumber, request.PageSize);
    }
}