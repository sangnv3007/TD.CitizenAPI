using TD.CitizenAPI.Application.Catalog.Degrees;
using TD.CitizenAPI.Application.Catalog.Experiences;
using TD.CitizenAPI.Application.Catalog.JobNames;
using TD.CitizenAPI.Application.Catalog.JobPositions;
using TD.CitizenAPI.Application.Catalog.JobTypes;
using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class JobApplicationDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ImageUrl { get; set; }

    public string? Name { get; set; }
    public string? CVFile { get; set; }
    public string? Image { get; set; }
    //Vi tri hien tai
    public Guid? CurrentPositionId { get; set; }
    //Vi tri mong muon
    public Guid? PositionId { get; set; }
    public Guid? JobNameId { get; set; }

    //Trinh do hoc van
    public Guid? DegreeId { get; set; }
    //Tong so nam Kinh nghiem
    public Guid? ExperienceId { get; set; }

    //Mong muon muc luong toi thieu
    public int? MinExpectedSalary { get; set; }
    //Dia diem lam viec
    public string? Address { get; set; }
    //Hinh thuc lam viec
    public Guid? JobTypeId { get; set; }
    //Cho phep nguoi khac tim kiem thong tin
    public int? IsSearchAllowed { get; set; }
    public UserDetailsDto? User { get; set; }

    public virtual JobPositionDto? CurrentPosition { get; set; }
    public virtual JobNameDto? JobName { get; set; }
    public virtual JobPositionDto? Position { get; set; }
    public virtual ExperienceDto? Experience { get; set; }
    public virtual DegreeDto? Degree { get; set; }
    public virtual JobTypeDto? JobType { get; set; }
}