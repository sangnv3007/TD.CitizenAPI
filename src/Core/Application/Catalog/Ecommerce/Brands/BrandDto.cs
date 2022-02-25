namespace TD.CitizenAPI.Application.Catalog.Brands;

public class BrandDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; private set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
}