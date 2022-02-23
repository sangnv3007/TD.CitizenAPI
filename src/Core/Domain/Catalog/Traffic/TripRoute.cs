namespace TD.CitizenAPI.Domain.Catalog;

public class TripRoute : AuditableEntity, IAggregateRoot
{
    public string? Type { get; set; }
    public string? Description { get; set; }
    public Guid? TripId { get; set; }
    public Trip? Trip { get; set; }

    public string? PlaceName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
    public int? Duration { get; set; }
    public bool? Status { get; set; }


    public virtual Area? Province { get; set; }
    public virtual Area? District { get; set; }
    public virtual Area? Commune { get; set; }

    public TripRoute(string? type, string? description, Guid? tripId, string? placeName, double? latitude, double? longitude, Guid? provinceId, Guid? districtId, Guid? communeId, int? duration, bool? status)
    {
        Type = type;
        Description = description;
        TripId = tripId;
        PlaceName = placeName;
        Latitude = latitude;
        Longitude = longitude;
        ProvinceId = provinceId;
        DistrictId = districtId;
        CommuneId = communeId;
        Duration = duration;
        Status = status;
    }

    public TripRoute Update(string? type, string? description, Guid? tripId, string? placeName, double? latitude, double? longitude, Guid? provinceId, Guid? districtId, Guid? communeId, int? duration, bool? status)
    {
        if (type is not null && Type?.Equals(type) is not true) Type = type;
       
        if (description is not null && Description?.Equals(description) is not true) Description = description;


        if (placeName is not null && PlaceName?.Equals(placeName) is not true) PlaceName = placeName;

        if (provinceId.HasValue && provinceId.Value != Guid.Empty && !ProvinceId.Equals(provinceId.Value)) ProvinceId = provinceId.Value;
        if (districtId.HasValue && districtId.Value != Guid.Empty && !DistrictId.Equals(districtId.Value)) DistrictId = districtId.Value;
        if (communeId.HasValue && communeId.Value != Guid.Empty && !CommuneId.Equals(communeId.Value)) CommuneId = communeId.Value;
        if (latitude.HasValue && !Latitude.Equals(latitude.Value)) Latitude = latitude.Value;
        if (longitude.HasValue && !Longitude.Equals(longitude.Value)) Longitude = longitude.Value;


        if (tripId.HasValue && tripId.Value != Guid.Empty && !TripId.Equals(tripId.Value)) TripId = tripId.Value;

        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;
        if (duration.HasValue && !Duration.Equals(duration.Value)) Duration = duration.Value;

        return this;
    }
}