namespace TD.CitizenAPI.Domain.Catalog;

public class Hotline : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? Code { get; set; }
    public string? Detail { get; set; }
    public string? OtherDetail { get; set; }
    public string? Phone { get; set; }
    public string? Image { get; set; }
    public bool? Active { get; set; }
    public int? Order { get; set; }
    public Guid? HotlineCategoryId { get; set; }
    public HotlineCategory? HotlineCategory { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public Hotline(string name, string? address, string? code, string? detail, string? otherDetail, string? phone, string? image, bool? active, int? order, Guid? hotlineCategoryId, double? latitude, double? longitude)
    {
        Name = name;
        Address = address;
        Code = code;
        Detail = detail;
        OtherDetail = otherDetail;
        Phone = phone;
        Image = image;
        Active = active;
        Order = order;
        HotlineCategoryId = hotlineCategoryId;
        Latitude = latitude;
        Longitude = longitude;
    }

    public Hotline Update(string? name, string? address, string? code, string? detail, string? otherDetail, string? phone, string? image, bool? active, int? order, Guid? hotlineCategoryId, double? latitude, double? longitude)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (detail is not null && Detail?.Equals(detail) is not true) Detail = detail;
        if (otherDetail is not null && OtherDetail?.Equals(otherDetail) is not true) OtherDetail = otherDetail;
        if (phone is not null && Phone?.Equals(phone) is not true) Phone = phone;

        if (longitude.HasValue && Longitude != longitude) Longitude = longitude.Value;
        if (latitude.HasValue && Latitude != latitude) Latitude = latitude.Value;
        if (active.HasValue && Active != active) Active = active.Value;
        if (order.HasValue && Order != order) Order = order.Value;
        if (hotlineCategoryId.HasValue && hotlineCategoryId.Value != Guid.Empty && !HotlineCategoryId.Equals(hotlineCategoryId.Value)) HotlineCategoryId = hotlineCategoryId.Value;
        return this;
    }
}