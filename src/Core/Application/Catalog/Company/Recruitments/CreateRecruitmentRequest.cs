namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class CreateRecruitmentRequest : IRequest<Result<Guid>>
{
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    //Cong ty
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

    //yeu cau khac
    public string? OtherRequirement { get; set; }
    //ho so bao gom
    public string? ResumeRequirement { get; set; }

    public DateTime? ResumeApplyExpired { get; set; }
    //So luong
    public int? NumberOfJob { get; set; }
    public int? Status { get; set; }

    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactAdress { get; set; }

    public string? Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }

}

public class CreateRecruitmentRequestValidator : CustomValidator<CreateRecruitmentRequest>
{
    public CreateRecruitmentRequestValidator(IReadRepository<Recruitment> repository, IStringLocalizer<CreateRecruitmentRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateRecruitmentRequestHandler : IRequestHandler<CreateRecruitmentRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Recruitment> _repository;

    public CreateRecruitmentRequestHandler(IRepositoryWithEvents<Recruitment> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateRecruitmentRequest request, CancellationToken cancellationToken)
    {
        var item = new Recruitment(request.UserName, request.Name, request.Description, request.Image,request.CompanyId,request.JobTypeId,request.JobNameId, request.JobPositionId, request.SalaryId, request.ExperienceId, request.Gender, request.JobAgeId, request.DegreeId, request.OtherRequirement, request.ResumeRequirement, request.ResumeApplyExpired, request.NumberOfJob, request.Status, request.ContactName, request.ContactEmail, request.ContactPhone, request.ContactAdress, request.Address, request.Latitude, request.Longitude, request.ProvinceId, request.DistrictId, request.CommuneId);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}