namespace TD.CitizenAPI.Application.Catalog.TripRoutes;

public class TripRouteDetailsDto : IDto
{
    public Guid Id { get; set; }
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
}