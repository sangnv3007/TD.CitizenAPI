namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class AttributeDatetimeDto : IDto
{
    public Guid Id { get; set; }
    public DateTime Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }
}