using TD.CitizenAPI.Application.Catalog.Brands;

namespace TD.CitizenAPI.Application.Catalog.FoodWarnings;

public class FoodWarningDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime? CreatedOn { get; set; }
}