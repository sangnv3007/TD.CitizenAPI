namespace TD.CitizenAPI.Application.Catalog.VehicleTypes;

public class VehicleTypeDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public int? SeatCount { get; set; }
    public string? Description { get; set; }
}