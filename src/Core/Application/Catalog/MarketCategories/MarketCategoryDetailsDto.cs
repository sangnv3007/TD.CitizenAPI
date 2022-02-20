using TD.CitizenAPI.Application.Catalog.Brands;

namespace TD.CitizenAPI.Application.Catalog.MarketCategories;

public class MarketCategoryDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}