namespace TD.CitizenAPI.Domain.Catalog;

public class JobApplication : AuditableEntity, IAggregateRoot
{
    // Hồ sơ nghề nghiệp
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

    public JobApplication(string? userName, string? name, string? cVFile, string? image, Guid? currentPositionId, Guid? positionId, Guid? jobNameId, Guid? degreeId, Guid? experienceId, int? minExpectedSalary, string? address, Guid? jobTypeId, int? isSearchAllowed)
    {
        UserName = userName;
        Name = name;
        CVFile = cVFile;
        Image = image;
        CurrentPositionId = currentPositionId;
        PositionId = positionId;
        JobNameId = jobNameId;
        DegreeId = degreeId;
        ExperienceId = experienceId;
        MinExpectedSalary = minExpectedSalary;
        Address = address;
        JobTypeId = jobTypeId;
        IsSearchAllowed = isSearchAllowed;
    }

    public JobApplication Update(string? userName, string? name, string? cVFile, string? image, Guid? currentPositionId, Guid? positionId, Guid? jobNameId, Guid? degreeId, Guid? experienceId, int? minExpectedSalary, string? address, Guid? jobTypeId, int? isSearchAllowed)
    {
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (cVFile is not null && CVFile?.Equals(cVFile) is not true) CVFile = cVFile;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (address is not null && Address?.Equals(address) is not true) Address = address;


        if (currentPositionId.HasValue && currentPositionId.Value != Guid.Empty && !CurrentPositionId.Equals(currentPositionId.Value)) CurrentPositionId = currentPositionId.Value;
        if (positionId.HasValue && positionId.Value != Guid.Empty && !PositionId.Equals(positionId.Value)) PositionId = positionId.Value;
        if (jobNameId.HasValue && jobNameId.Value != Guid.Empty && !JobNameId.Equals(jobNameId.Value)) JobNameId = jobNameId.Value;
        if (degreeId.HasValue && degreeId.Value != Guid.Empty && !DegreeId.Equals(degreeId.Value)) DegreeId = degreeId.Value;
        if (experienceId.HasValue && experienceId.Value != Guid.Empty && !ExperienceId.Equals(experienceId.Value)) ExperienceId = experienceId.Value;
        if (jobTypeId.HasValue && jobTypeId.Value != Guid.Empty && !JobTypeId.Equals(jobTypeId.Value)) JobTypeId = jobTypeId.Value;

        if (minExpectedSalary.HasValue && !MinExpectedSalary.Equals(minExpectedSalary.Value)) MinExpectedSalary = minExpectedSalary.Value;
        if (isSearchAllowed.HasValue && !IsSearchAllowed.Equals(isSearchAllowed.Value)) IsSearchAllowed = isSearchAllowed.Value;

        return this;
    }

   
}