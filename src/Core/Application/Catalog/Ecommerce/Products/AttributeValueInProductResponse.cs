using TD.CitizenAPI.Application.Catalog.Attributes;

namespace TD.CitizenAPI.Application.Catalog.Products;

public class AttributeValueInProductResponse : IDto
{
    public string Code { get; set; } = default!;
    public object Value { get; set; } = null!;
    public AttributeDto? Attribute { get; set; }
}