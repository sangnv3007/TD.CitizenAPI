using TD.CitizenAPI.Application.Catalog.Industries;

namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class RecruitmentBenefitDto : IDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public Guid? BenefitId { get; set; }
    public virtual Benefit? Benefit { get; set; }
}