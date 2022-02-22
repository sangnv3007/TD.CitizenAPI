using TD.CitizenAPI.Application.Catalog.Brands;

namespace TD.CitizenAPI.Application.Catalog.HotlineCategories;

public class HotlineCategoryDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
}