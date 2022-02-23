namespace TD.CitizenAPI.Domain.Catalog;

public class JobApplied : AuditableEntity, IAggregateRoot
{
    //Viec da ứng tuyển
    public string? UserName { get; set; }
    public Guid? JobApplicationId { get; set; }
    public Guid? RecruitmentId { get; set; }
    public int? Status { get; set; }
    public virtual Recruitment? Recruitment { get; set; }
    public virtual JobApplication? JobApplication { get; set; }

    public JobApplied(string? userName, Guid? jobApplicationId, Guid? recruitmentId, int? status)
    {
        UserName = userName;
        JobApplicationId = jobApplicationId;
        RecruitmentId = recruitmentId;
        Status = status;
    }

    public JobApplied Update(int? status)
    {
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;
        return this;
    }
}