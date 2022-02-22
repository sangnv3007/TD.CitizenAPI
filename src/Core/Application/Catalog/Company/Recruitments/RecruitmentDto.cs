using TD.CitizenAPI.Application.Catalog.Companies;
using TD.CitizenAPI.Application.Catalog.JobNames;
using TD.CitizenAPI.Application.Catalog.JobPositions;
using TD.CitizenAPI.Application.Catalog.JobTypes;
using TD.CitizenAPI.Application.Catalog.Salaries;

namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class RecruitmentDto : IDto
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
    public virtual CompanyDto? Company { get; set; }
    public virtual JobPositionDto? JobPosition { get; set; }
    public virtual JobTypeDto? JobType { get; set; }
    public virtual JobNameDto? JobName { get; set; }
    public virtual SalaryDto? Salary { get; set; }
  
}