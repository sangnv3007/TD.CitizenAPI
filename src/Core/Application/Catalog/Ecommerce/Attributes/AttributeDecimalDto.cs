namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class AttributeDecimalDto : IDto
{
    public Guid Id { get; set; }
    public decimal Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }

}