using TD.CitizenAPI.Application.Catalog.JobApplications;
using TD.CitizenAPI.Application.Catalog.Recruitments;

namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public class JobAppliedDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public int? Status { get; set; }
    public Guid? JobApplicationId { get; set; }
    public Guid? RecruitmentId { get; set; }
    public virtual RecruitmentDto? Recruitment { get; set; }
    public virtual JobApplicationDto? JobApplication { get; set; }
}