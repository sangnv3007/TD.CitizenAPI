namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class VehicleDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? DriverName { get; set; }
    public string? DriverPhone { get; set; }
    public string? Icon { get; set; }
   
    public Guid? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

  
}