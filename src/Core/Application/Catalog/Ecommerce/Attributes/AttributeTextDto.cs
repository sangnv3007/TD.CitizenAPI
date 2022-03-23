namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class AttributeTextDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }
}