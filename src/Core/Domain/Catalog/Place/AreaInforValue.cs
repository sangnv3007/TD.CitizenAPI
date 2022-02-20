namespace TD.CitizenAPI.Domain.Catalog;

public class AreaInforValue : AuditableEntity, IAggregateRoot
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public string? Type { get; set; }
    public int Order { get; set; }
    public Guid? AreaInforId { get; set; }
    public virtual AreaInfor? AreaInfor { get; set; }

    public AreaInforValue(string? key, string? value, string? type, int order, Guid? areaInforId)
    {
        Key = key;
        Value = value;
        Type = type;
        Order = order;
        AreaInforId = areaInforId;
    }

    public AreaInforValue Update(string? key, string? value, string? type, int? order, Guid? areaInforId)
    {
        if (key is not null && Key?.Equals(key) is not true) Key = key;
        if (value is not null && Value?.Equals(value) is not true) Value = value;
        if (type is not null && Type?.Equals(type) is not true) Type = type;
        if (order is not null && order.HasValue && order != Order) Order = order.Value;
        if (areaInforId.HasValue && areaInforId.Value != Guid.Empty && !AreaInforId.Equals(areaInforId.Value)) AreaInforId = areaInforId.Value;

        return this;
    }
}