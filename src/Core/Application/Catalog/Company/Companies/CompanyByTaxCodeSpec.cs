namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CompanyByTaxCodeSpec : Specification<Company>, ISingleResultSpecification
{
    public CompanyByTaxCodeSpec(string? taxCode) =>
        Query.Where(p => p.TaxCode == taxCode, taxCode is not null);

}