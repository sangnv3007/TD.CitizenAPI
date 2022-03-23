namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CompanyIndustryByCompanySpec : Specification<CompanyIndustry>, ISingleResultSpecification
{
    public CompanyIndustryByCompanySpec(Guid companyId) =>
        Query.Where(p => p.CompanyId == companyId);

}