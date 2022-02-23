namespace TD.CitizenAPI.Domain.Catalog;

public class CompanyCarPolicy : AuditableEntity, IAggregateRoot
{
    public Guid? CompanyId { get; set; }
    public Guid? CarPolicyId { get; set; }
    public Company? Company { get; set; }
    public CarPolicy? CarPolicy { get; set; }

    public CompanyCarPolicy(Guid? companyId, Guid? carPolicyId)
    {
        CompanyId = companyId;
        CarPolicyId = carPolicyId;
    }

    public CompanyCarPolicy Update(Guid? companyId, Guid? carPolicyId)
    {
        if (companyId.HasValue && companyId.Value != Guid.Empty && !CompanyId.Equals(companyId.Value)) CompanyId = companyId.Value;
        if (carPolicyId.HasValue && carPolicyId.Value != Guid.Empty && !CarPolicyId.Equals(carPolicyId.Value)) CarPolicyId = carPolicyId.Value;

        return this;
    }
}