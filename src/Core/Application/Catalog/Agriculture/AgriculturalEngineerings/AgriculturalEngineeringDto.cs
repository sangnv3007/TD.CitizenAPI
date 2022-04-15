namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class AgriculturalEngineeringDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid? AgriculturalEngineeringCategoryId { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public int ViewQuantity { get; set; } = 0;
    public AgriculturalEngineeringCategory? AgriculturalEngineeringCategory;

}