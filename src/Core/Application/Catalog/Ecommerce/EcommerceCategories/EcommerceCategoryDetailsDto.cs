namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class EcommerceCategoryDetailsDto : IDto
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }

    public List<Guid>? ParentsId { get; set; }


    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public int? Position { get; set; }
    public bool? IncludeInMenu { get; set; }
    public int? Level { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string[]? Tags { get; set; }
    public int? Status { get; set; }
    public bool? IsActive { get; set; }
    //public virtual EcommerceCategoryDetailsDto? Parent { get; set; }

}