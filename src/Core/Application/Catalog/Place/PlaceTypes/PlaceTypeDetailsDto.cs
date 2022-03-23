using TD.CitizenAPI.Application.Catalog.Categories;

namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class PlaceTypeDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
    public CategoryDto Category { get; set; } = default!;
    public Guid? CategoryId { get; set; }

}