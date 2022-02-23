using TD.CitizenAPI.Application.Catalog.Recruitments;

namespace TD.CitizenAPI.Application.Catalog.JobSaveds;

public class JobSavedDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public Guid? RecruitmentId { get; set; }
    public virtual RecruitmentDto? Recruitment { get; set; }
}