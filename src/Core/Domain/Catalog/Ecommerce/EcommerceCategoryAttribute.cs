namespace TD.CitizenAPI.Domain.Catalog;

public class EcommerceCategoryAttribute : AuditableEntity, IAggregateRoot
{
    public Guid? EcommerceCategoryId { get; set; }
    public Guid? AttributeId { get; set; }
    public int Position { get; set; } = 0;
    public virtual Attribute? Attribute { get; set; }
    public EcommerceCategory? EcommerceCategory { get; set; }

    public EcommerceCategoryAttribute(Guid? ecommerceCategoryId, Guid? attributeId, int position)
    {
        EcommerceCategoryId = ecommerceCategoryId;
        AttributeId = attributeId;
        Position = position;
    }

    public EcommerceCategoryAttribute Update(Guid? ecommerceCategoryId, Guid? attributeId, int? position)
    {
        if (position.HasValue && Position != position) Position = position.Value;
        if (ecommerceCategoryId.HasValue && ecommerceCategoryId.Value != Guid.Empty && !EcommerceCategoryId.Equals(ecommerceCategoryId.Value)) EcommerceCategoryId = ecommerceCategoryId.Value;
        if (attributeId.HasValue && attributeId.Value != Guid.Empty && !AttributeId.Equals(attributeId.Value)) AttributeId = attributeId.Value;
        return this;
    }

}