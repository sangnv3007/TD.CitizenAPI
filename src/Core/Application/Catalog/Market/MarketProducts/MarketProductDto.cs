namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class MarketProductDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Packaging { get; set; }
    public int Price { get; set; }
    public string? Brand { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
}