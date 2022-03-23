namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class MarketProductDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Packaging { get; set; }
    public int Price { get; set; }
    public string? Brand { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Unit { get; set; }
    public string? Origin { get; set; }
    public string? Description { get; set; }
    public string? DisplayUnit { get; set; }
    public string? DisplayFactor { get; set; }
    public virtual MarketCategory? MarketCategory { get; set; }
    public Guid? MarketCategoryId { get; set; }

}