namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class UpdateRecruitmentRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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

public class UpdateRecruitmentRequestValidator : CustomValidator<UpdateRecruitmentRequest>
{
    public UpdateRecruitmentRequestValidator(IRepository<Recruitment> repository, IStringLocalizer<UpdateRecruitmentRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateRecruitmentRequestHandler : IRequestHandler<UpdateRecruitmentRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Recruitment> _repository;
    private readonly IStringLocalizer<UpdateRecruitmentRequestHandler> _localizer;

    public UpdateRecruitmentRequestHandler(IRepositoryWithEvents<Recruitment> repository, IStringLocalizer<UpdateRecruitmentRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateRecruitmentRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Recruitment.notfound"], request.Id));

        item.Update(request.UserName, request.Name, request.Description, request.Image, request.CompanyId, request.JobTypeId, request.JobNameId, request.JobPositionId, request.SalaryId, request.ExperienceId, request.Gender, request.JobAgeId, request.DegreeId, request.OtherRequirement, request.ResumeRequirement, request.ResumeApplyExpired, request.NumberOfJob, request.Status, request.ContactName, request.ContactEmail, request.ContactPhone, request.ContactAdress, request.Address, request.Latitude, request.Longitude, request.ProvinceId, request.DistrictId, request.CommuneId);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}