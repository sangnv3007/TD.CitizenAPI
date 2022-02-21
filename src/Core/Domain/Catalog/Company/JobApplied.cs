namespace TD.CitizenAPI.Domain.Catalog;

public class JobApplied : AuditableEntity, IAggregateRoot
{
    //Viec da ứng tuyển
    public string? UserName { get; set; }
    public string? CVFile { get; set; }
    public Guid? RecruitmentId { get; set; }
    public virtual Recruitment? Recruitment { get; set; }

    public JobApplied(string? userName, string? cVFile, Guid? recruitmentId)
    {
        UserName = userName;
        CVFile = cVFile;
        RecruitmentId = recruitmentId;
    }

    public JobApplied Update(string? name, string? code,  string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        return this;
    }
}