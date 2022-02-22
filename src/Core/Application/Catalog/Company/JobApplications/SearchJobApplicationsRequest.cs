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

public class JobNamesBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobName, JobApplicationDto>
{
    public JobNamesBySearchRequestSpec(SearchJobApplicationsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchJobNamesRequestHandler : IRequestHandler<SearchJobApplicationsRequest, PaginationResponse<JobApplicationDto>>
{
    private readonly IReadRepository<JobName> _repository;

    public SearchJobNamesRequestHandler(IReadRepository<JobName> repository) => _repository = repository;

    public async Task<PaginationResponse<JobApplicationDto>> Handle(SearchJobApplicationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobNamesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<JobApplicationDto>(list, count, request.PageNumber, request.PageSize);
    }
}