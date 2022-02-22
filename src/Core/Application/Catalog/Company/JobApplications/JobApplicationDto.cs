namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class JobApplicationDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
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

    public virtual JobPosition? CurrentPosition { get; set; }
    public virtual JobName? JobName { get; set; }
    public virtual JobPosition? Position { get; set; }
    public virtual Experience? Experience { get; set; }
    public virtual Degree? Degree { get; set; }
    public virtual JobType? JobType { get; set; }
}