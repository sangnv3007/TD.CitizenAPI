namespace TD.CitizenAPI.Application.Catalog.MedicalHotlines;

public class MedicalHotlineDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    public string? Code { get; set; }
    public string? Detail { get; set; }
    public string? OtherDetail { get; set; }
    public string? Phone { get; set; }
    public string? Image { get; set; }
    public bool? Active { get; set; }
    public int? Order { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}