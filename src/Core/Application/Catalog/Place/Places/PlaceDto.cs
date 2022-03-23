using TD.CitizenAPI.Application.Catalog.PlaceTypes;

namespace TD.CitizenAPI.Application.Catalog.Places;

public class PlaceDto : IDto
{
    public Guid Id { get; set; }
    public string? PlaceName { get; set; }
    public string? Title { get; set; }
    public string? AddressDetail { get; set; }
    public string? PhoneContact { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Status { get; set; }
    public PlaceTypeDto? PlaceType { get; set; }
}