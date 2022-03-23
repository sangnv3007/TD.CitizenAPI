namespace TD.CitizenAPI.Application.Catalog.Places;

public class PlaceDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string? PlaceName { get; set; }
    public string? Title { get; set; }
    public string? AddressDetail { get; set; }
    public string? Source { get; set; }
    public string? ExtraInfo { get; set; }
    public string? PhoneContact { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? Content { get; set; }
    public string? ContentHtml { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public string? Tags { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Status { get; set; }

    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public DateTime? TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }

    public PlaceType? PlaceType { get; set; }
    public Guid? PlaceTypeId { get; set; }

    public Area? Province { get; set; }
    public Area? District { get; set; }
    public Area? Commune { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
}