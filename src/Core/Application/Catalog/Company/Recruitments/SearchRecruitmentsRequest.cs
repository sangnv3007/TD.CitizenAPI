namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class SearchRecruitmentsRequest : PaginationFilter, IRequest<PaginationResponse<RecruitmentDto>>
{
    public string? UserName { get; set; }
    public Guid? CompanyId { get; set; }
    //Loai hinh cong viec
    public Guid? JobTypeId { get; set; }
    //Nghe nghiep
    public Guid? JobNameId { get; set; }
    //Vi tri
    public Guid? JobPositionId { get; set; }
    //Muc luong
    public Guid? SalaryId { get; set; }

    //Kinh nghiem
    public Guid? ExperienceId { get; set; }
    //Yeu cau gioi tinh
    public string? Gender { get; set; }

    public Guid? JobAgeId { get; set; }
    public Guid? DegreeId { get; set; }

    public string? ResumeApplyExpiredFrom { get; set; }
    public string? ResumeApplyExpiredTo { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
}



public class SearchRecruitmentsRequestHandler : IRequestHandler<SearchRecruitmentsRequest, PaginationResponse<RecruitmentDto>>
{
    private readonly IReadRepository<Recruitment> _repository;

    public SearchRecruitmentsRequestHandler(IReadRepository<Recruitment> repository) => _repository = repository;

    public async Task<PaginationResponse<RecruitmentDto>> Handle(SearchRecruitmentsRequest request, CancellationToken cancellationToken)
    {
        var spec = new RecruitmentsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<RecruitmentDto>(list, count, request.PageNumber, request.PageSize);
    }
}