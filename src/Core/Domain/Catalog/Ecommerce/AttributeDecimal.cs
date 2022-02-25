namespace TD.CitizenAPI.Domain.Catalog;

public class AttributeDecimal : AuditableEntity, IAggregateRoot
{
    public decimal Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }

    public virtual Product? Product { get; set; }
    public virtual Attribute? Attribute { get; set; }

    public AttributeDecimal(decimal value, Guid? attributeId, Guid? productId)
    {
        Value = value;
        AttributeId = attributeId;
        ProductId = productId;
    }
}