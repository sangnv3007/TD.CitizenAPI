using TD.CitizenAPI.Application.Catalog.Industries;

namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CompanyIndustryDto : IDto
{
    public Guid Id { get; set; }
    public Guid? IndustryId { get; set; }
    public IndustryDto? Industry { get; set; }


}