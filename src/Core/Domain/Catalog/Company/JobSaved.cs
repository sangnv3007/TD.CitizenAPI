namespace TD.CitizenAPI.Domain.Catalog;

public class JobSaved : AuditableEntity, IAggregateRoot
{
    //Viec da luu
    public string? UserName { get; set; }
    public Guid? RecruitmentId { get; set; }
    public virtual Recruitment? Recruitment { get; set; }

    public JobSaved(string? userName, Guid? recruitmentId)
    {
        UserName = userName;
        RecruitmentId = recruitmentId;
    }

    public JobSaved Update(string? userName, Guid? recruitmentId)
    {
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (recruitmentId.HasValue && recruitmentId.Value != Guid.Empty && !RecruitmentId.Equals(recruitmentId.Value)) RecruitmentId = recruitmentId.Value;

        return this;
    }
}