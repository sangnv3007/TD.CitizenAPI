namespace TD.CitizenAPI.Domain.Catalog;

public class AttributeVarchar : AuditableEntity, IAggregateRoot
{
    public string Value { get; set; }
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }

    public virtual Product? Product { get; set; }
    public virtual Attribute? Attribute { get; set; }

    public AttributeVarchar(string value, Guid? attributeId, Guid? productId)
    {
        Value = value;
        AttributeId = attributeId;
        ProductId = productId;
    }

    public AttributeVarchar()
    {
    }
}