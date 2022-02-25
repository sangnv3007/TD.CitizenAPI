namespace TD.CitizenAPI.Domain.Catalog;

public class AttributeValue : AuditableEntity, IAggregateRoot
{
    public string Value { get; set; }
    public Guid? AttributeId { get; set; }
    public int Position { get; set; } = 0;
    public bool IsDefault { get; set; } = false;
    public int Status { get; set; } = 1;

    public virtual Attribute? Attribute { get; set; }

    public AttributeValue(string value, Guid? attributeId, int position, bool isDefault, int status)
    {
        Value = value;
        AttributeId = attributeId;
        Position = position;
        IsDefault = isDefault;
        Status = status;
    }

    public AttributeValue Update(string? value, Guid? attributeId, int? position, bool? isDefault)
    {
        if (value is not null && Value?.Equals(value) is not true)
        {
            Value = value;
        }
        if (attributeId.HasValue && attributeId.Value != Guid.Empty && !AttributeId.Equals(attributeId.Value)) AttributeId = attributeId.Value;
        if (position.HasValue && Position != position) Position = position.Value;
        if (isDefault.HasValue && IsDefault != isDefault) IsDefault = isDefault.Value;



        return this;
    }
}