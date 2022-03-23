using TD.CitizenAPI.Application.Catalog.Areas;
using TD.CitizenAPI.Application.Catalog.Companies;
using TD.CitizenAPI.Application.Catalog.Degrees;
using TD.CitizenAPI.Application.Catalog.Experiences;
using TD.CitizenAPI.Application.Catalog.JobAges;
using TD.CitizenAPI.Application.Catalog.JobNames;
using TD.CitizenAPI.Application.Catalog.JobPositions;
using TD.CitizenAPI.Application.Catalog.JobTypes;
using TD.CitizenAPI.Application.Catalog.Salaries;

namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class RecruitmentDetailsDto : IDto
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

    public virtual ICollection<RecruitmentBenefitDto>? RecruitmentBenefits { get; set; }


    public virtual CompanyDto? Company { get; set; }
    public virtual JobPositionDto? JobPosition { get; set; }
    public virtual JobTypeDto? JobType { get; set; }
    public virtual JobNameDto? JobName { get; set; }
    public virtual SalaryDto? Salary { get; set; }
    public virtual JobAgeDto? JobAge { get; set; }
    public virtual DegreeDto? Degree { get; set; }
    public virtual ExperienceDto? Experience { get; set; }

    public virtual AreaDto? Province { get; set; }
    public virtual AreaDto? District { get; set; }
    public virtual AreaDto? Commune { get; set; }
}