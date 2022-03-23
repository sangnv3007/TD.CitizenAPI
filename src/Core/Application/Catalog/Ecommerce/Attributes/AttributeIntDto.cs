namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class AttributeIntDto : IDto
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }
}