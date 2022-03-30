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
    //So ghe
    public int? SeatLimit { get; set; }
    //Trang thai su dung
    public bool? Status { get; set; }
    //Loai ghe
    public string? SeatType { get; set; }
    //Bien so xe
    public string? RegistrationPlate { get; set; }

    public Guid? VehicleTypeId { get; set; }
    public virtual VehicleType? VehicleType { get; set; }
    public Guid? CompanyId { get; set; }
    public virtual Company? Company { get; set; }


}