namespace TD.CitizenAPI.Domain.Catalog;

public class Recruitment : AuditableEntity, IAggregateRoot
{
    //Tin tuyen dung
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

    public virtual Company? Company { get; set; }
    public virtual JobPosition? JobPosition { get; set; }
    public virtual JobType? JobType { get; set; }
    public virtual JobName? JobName { get; set; }
    public virtual Salary? Salary { get; set; }
    public virtual JobAge? JobAge { get; set; }
    public virtual Degree? Degree { get; set; }
    public virtual Experience? Experience { get; set; }

    public virtual Area? Province { get; set; }
    public virtual Area? District { get; set; }
    public virtual Area? Commune { get; set; }

    public virtual ICollection<RecruitmentBenefit>? RecruitmentBenefits { get; set; }


    public Recruitment(string? userName, string? name, string? description, string? image, Guid? companyId, Guid? jobTypeId, Guid? jobNameId, Guid? jobPositionId, Guid? salaryId, Guid? experienceId, string? gender, Guid? jobAgeId, Guid? degreeId, string? otherRequirement, string? resumeRequirement, DateTime? resumeApplyExpired, int? numberOfJob, int? status, string? contactName, string? contactEmail, string? contactPhone, string? contactAdress, string? address, double? latitude, double? longitude, Guid? provinceId, Guid? districtId, Guid? communeId)
    {
        UserName = userName;
        Name = name;
        Description = description;
        Image = image;
        CompanyId = companyId;
        JobTypeId = jobTypeId;
        JobNameId = jobNameId;
        JobPositionId = jobPositionId;
        SalaryId = salaryId;
        ExperienceId = experienceId;
        Gender = gender;
        JobAgeId = jobAgeId;
        DegreeId = degreeId;
        OtherRequirement = otherRequirement;
        ResumeRequirement = resumeRequirement;
        ResumeApplyExpired = resumeApplyExpired;
        NumberOfJob = numberOfJob;
        Status = status;
        ContactName = contactName;
        ContactEmail = contactEmail;
        ContactPhone = contactPhone;
        ContactAdress = contactAdress;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        ProvinceId = provinceId;
        DistrictId = districtId;
        CommuneId = communeId;
    }

    public Recruitment Update(string? userName, string? name, string? description, string? image, Guid? companyId, Guid? jobTypeId, Guid? jobNameId, Guid? jobPositionId, Guid? salaryId, Guid? experienceId, string? gender, Guid? jobAgeId, Guid? degreeId, string? otherRequirement, string? resumeRequirement, DateTime? resumeApplyExpired, int? numberOfJob, int? status, string? contactName, string? contactEmail, string? contactPhone, string? contactAdress, string? address, double? latitude, double? longitude, Guid? provinceId, Guid? districtId, Guid? communeId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (gender is not null && Gender?.Equals(gender) is not true) Gender = gender;
        if (otherRequirement is not null && OtherRequirement?.Equals(otherRequirement) is not true) OtherRequirement = otherRequirement;
        if (resumeRequirement is not null && ResumeRequirement?.Equals(resumeRequirement) is not true) ResumeRequirement = resumeRequirement;
        if (contactName is not null && ContactName?.Equals(contactName) is not true) ContactName = contactName;
        if (contactEmail is not null && ContactEmail?.Equals(contactEmail) is not true) ContactEmail = contactEmail;
        if (contactPhone is not null && ContactPhone?.Equals(contactPhone) is not true) ContactPhone = contactPhone;
        if (contactAdress is not null && ContactAdress?.Equals(contactAdress) is not true) ContactAdress = contactAdress;

        if (numberOfJob.HasValue && !NumberOfJob.Equals(numberOfJob.Value)) NumberOfJob = numberOfJob.Value;
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;

        if (companyId.HasValue && companyId.Value != Guid.Empty && !CompanyId.Equals(companyId.Value)) CompanyId = companyId.Value;
        if (jobTypeId.HasValue && jobTypeId.Value != Guid.Empty && !JobTypeId.Equals(jobTypeId.Value)) JobTypeId = jobTypeId.Value;
        if (jobNameId.HasValue && jobNameId.Value != Guid.Empty && !JobNameId.Equals(jobNameId.Value)) JobNameId = jobNameId.Value;
        if (jobPositionId.HasValue && jobPositionId.Value != Guid.Empty && !JobPositionId.Equals(jobPositionId.Value)) JobPositionId = jobPositionId.Value;
        if (salaryId.HasValue && salaryId.Value != Guid.Empty && !jobPositionId.Equals(salaryId.Value)) SalaryId = salaryId.Value;
        if (experienceId.HasValue && experienceId.Value != Guid.Empty && !ExperienceId.Equals(experienceId.Value)) ExperienceId = experienceId.Value;
        if (jobAgeId.HasValue && jobAgeId.Value != Guid.Empty && !JobAgeId.Equals(jobAgeId.Value)) JobAgeId = jobAgeId.Value;
        if (degreeId.HasValue && degreeId.Value != Guid.Empty && !DegreeId.Equals(degreeId.Value)) DegreeId = degreeId.Value;


        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (provinceId.HasValue && provinceId.Value != Guid.Empty && !ProvinceId.Equals(provinceId.Value)) ProvinceId = provinceId.Value;
        if (districtId.HasValue && districtId.Value != Guid.Empty && !DistrictId.Equals(districtId.Value)) DistrictId = districtId.Value;
        if (communeId.HasValue && communeId.Value != Guid.Empty && !CommuneId.Equals(communeId.Value)) CommuneId = communeId.Value;
        if (latitude.HasValue && !Latitude.Equals(latitude.Value)) Latitude = latitude.Value;
        if (longitude.HasValue && !Longitude.Equals(longitude.Value)) Longitude = longitude.Value;
        if (resumeApplyExpired.HasValue && !ResumeApplyExpired.Equals(resumeApplyExpired.Value)) ResumeApplyExpired = resumeApplyExpired.Value;

        return this;
    }
}