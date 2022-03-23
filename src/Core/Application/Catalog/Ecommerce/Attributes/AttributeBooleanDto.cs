namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class AttributeBooleanDto : IDto
{
    public Guid Id { get; set; }
    public bool Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }
}