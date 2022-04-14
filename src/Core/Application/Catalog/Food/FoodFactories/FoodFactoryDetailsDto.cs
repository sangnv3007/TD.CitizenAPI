
namespace TD.CitizenAPI.Application.Catalog.FoodFactories;

public class FoodFactoryDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    //Linh vuc kinh doanh
    public string? BusinessArea { get; set; }

    //So chung nhan
    public string? CertificationNumber { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    //Chu co so
    public string? OwnerName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? TaxCode { get; set; }
    //Dia chi cong ty
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Files { get; set; }
    //Ngay cap
    public DateTime? DateOfIssue { get; set; }
    //Ngay het han
    public DateTime? ExpirationDate { get; set; }
}