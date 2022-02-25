namespace TD.CitizenAPI.Application.Catalog.Products;

public class AttributeValueInProduct : IDto
{
    public string Code { get; set; } = default!;
    public object Value { get; set; } = null!;
}