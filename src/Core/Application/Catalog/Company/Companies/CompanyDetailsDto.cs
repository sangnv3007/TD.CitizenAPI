using TD.CitizenAPI.Application.Catalog.Areas;

namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CompanyDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string Name { get; set; }
    public string? InternationalName { get; set; }
    public string? ShortName { get; set; }
    public string? TaxCode { get; set; }
    //Dia chi cong ty
    public string? Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
    //Dai dien
    public string? Representative { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? ProfileVideo { get; set; }
    public string? Fax { get; set; }
    //Ngay cap
    public DateTime? DateOfIssue { get; set; }
    //Linh vuc kinh doanh
    public string? BusinessSector { get; set; }
    public string? Images { get; set; }
    public string? Image { get; set; }
    public string? Logo { get; set; }
    public string? Description { get; set; }
    //Quy mo cong ty
    public string? CompanySize { get; set; }
    public int? Status { get; set; }

    public virtual AreaDto? Province { get; set; }
    public virtual AreaDto? District { get; set; }
    public virtual AreaDto? Commune { get; set; }
    public virtual ICollection<CompanyIndustryDto>? CompanyIndustries { get; set; }

}