namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CompanyDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string Name { get; set; } = default!;
    public string? InternationalName { get; set; }
    public string? ShortName { get; set; }

    //Dai dien
    public string? Representative { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Website { get; set; }
    public string? Address { get; set; }

    //Ngay cap
    //Linh vuc kinh doanh
    public string? BusinessSector { get; set; }
    public string? Image { get; set; }
    public string? Logo { get; set; }
    //Quy mo cong ty
    public string? CompanySize { get; set; }


}