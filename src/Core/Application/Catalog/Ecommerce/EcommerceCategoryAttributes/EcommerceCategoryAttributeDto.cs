using TD.CitizenAPI.Application.Catalog.Attributes;

namespace TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;

public class EcommerceCategoryAttributeDto : IDto
{
    public Guid Id { get; set; }
    public Guid? EcommerceCategoryId { get; set; }
    public Guid? AttributeId { get; set; }
    public int Position { get; set; } = 0;
    public virtual AttributeDto? Attribute { get; set; }
    public EcommerceCategoryAttributeDto? EcommerceCategory { get; set; }
}