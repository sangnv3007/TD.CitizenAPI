namespace TD.CitizenAPI.Domain.Catalog;

public class AttributeDatetime : AuditableEntity, IAggregateRoot
{
    public DateTime Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }

    public virtual Product? Product { get; set; }
    public virtual Attribute? Attribute { get; set; }

    public AttributeDatetime(DateTime value, Guid? attributeId, Guid? productId)
    {
        Value = value;
        AttributeId = attributeId;
        ProductId = productId;
    }
}