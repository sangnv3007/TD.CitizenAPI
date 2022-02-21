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

    public JobApplied Update(string? userName, string? cVFile, Guid? recruitmentId)
    {
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (cVFile is not null && CVFile?.Equals(cVFile) is not true) CVFile = cVFile;
        if (recruitmentId.HasValue && recruitmentId.Value != Guid.Empty && !RecruitmentId.Equals(recruitmentId.Value)) RecruitmentId = recruitmentId.Value;

        return this;
    }
}