namespace TD.CitizenAPI.Domain.Catalog;

public class CompanyIndustry : AuditableEntity, IAggregateRoot
{
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }
    public Guid? IndustryId { get; set; }
    public Industry? Industry { get; set; }

    public CompanyIndustry(Guid? companyId, Guid? industryId)
    {
        CompanyId = companyId;
        IndustryId = industryId;
    }

    public CompanyIndustry Update(Guid? companyId, Guid? industryId)
    {
        if (companyId.HasValue && companyId.Value != Guid.Empty && !CompanyId.Equals(companyId.Value)) CompanyId = companyId.Value;
        if (industryId.HasValue && industryId.Value != Guid.Empty && !IndustryId.Equals(industryId.Value)) IndustryId = industryId.Value;

        return this;
    }
}