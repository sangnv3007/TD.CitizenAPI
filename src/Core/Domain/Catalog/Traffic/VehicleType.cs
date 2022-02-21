namespace TD.CitizenAPI.Domain.Catalog;

public class VehicleType : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public int? SeatCount { get; set; }
    public string? Description { get; set; }

    public VehicleType(string name, string? code, string? icon, int? seatCount, string? description)
    {
        Name = name;
        Code = code;
        Icon = icon;
        SeatCount = seatCount;
        Description = description;
    }

    public VehicleType Update(string? name, string? code, string? icon, int? seatCount, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (icon is not null && Icon?.Equals(icon) is not true) Icon = icon;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (seatCount.HasValue && !SeatCount.Equals(seatCount.Value)) SeatCount = seatCount.Value;

        return this;
    }
}