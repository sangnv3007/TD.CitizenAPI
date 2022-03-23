namespace TD.CitizenAPI.Domain.Catalog;

public class RecruitmentBenefit : AuditableEntity, IAggregateRoot
{
    //phuc loi - tuyen dung
    public string? Name { get; set; }
    public Guid? RecruitmentId { get; set; }
    public virtual Recruitment? Recruitment { get; set; }
    public Guid? BenefitId { get; set; }
    public virtual Benefit? Benefit { get; set; }

    public RecruitmentBenefit(string? name, Guid? recruitmentId, Guid? benefitId)
    {
        Name = name;
        RecruitmentId = recruitmentId;
        BenefitId = benefitId;
    }

    public RecruitmentBenefit(Guid? recruitmentId, Guid? benefitId)
    {
        RecruitmentId = recruitmentId;
        BenefitId = benefitId;
    }

    public RecruitmentBenefit Update(string? name, Guid? recruitmentId, Guid? benefitId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (recruitmentId.HasValue && recruitmentId.Value != Guid.Empty && !RecruitmentId.Equals(recruitmentId.Value)) RecruitmentId = recruitmentId.Value;
        if (benefitId.HasValue && benefitId.Value != Guid.Empty && !BenefitId.Equals(benefitId.Value)) BenefitId = benefitId.Value;


        return this;
    }
}