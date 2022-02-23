namespace TD.CitizenAPI.Domain.Catalog;

public class Vehicle : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }
    public string Name { get; set; }
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

    public virtual ICollection<Trip>? Trips { get; set; }

    public virtual ICollection<VehicleCarUtility>? VehicleCarUtilities { get; set; }

    public Vehicle(string? userName, string name, string? description, string? image, string? images, string? driverName, string? driverPhone, string? icon, int? seatLimit, bool? status, string? seatType, string? registrationPlate, Guid? vehicleTypeId, Guid? companyId)
    {
        UserName = userName;
        Name = name;
        Description = description;
        Image = image;
        Images = images;
        DriverName = driverName;
        DriverPhone = driverPhone;
        Icon = icon;
        SeatLimit = seatLimit;
        Status = status;
        SeatType = seatType;
        RegistrationPlate = registrationPlate;
        VehicleTypeId = vehicleTypeId;
        CompanyId = companyId;
    }

    public Vehicle Update(string? userName, string name, string? description, string? image, string? images, string? driverName, string? driverPhone, string? icon, int? seatLimit, bool? status, string? seatType, string? registrationPlate, Guid? vehicleTypeId, Guid? companyId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (images is not null && Images?.Equals(images) is not true) Images = images;
        if (seatType is not null && SeatType?.Equals(seatType) is not true) SeatType = seatType;
        if (driverPhone is not null && DriverPhone?.Equals(driverPhone) is not true) DriverPhone = driverPhone;
        if (driverName is not null && DriverName?.Equals(driverName) is not true) DriverName = driverName;
        if (registrationPlate is not null && RegistrationPlate?.Equals(registrationPlate) is not true) RegistrationPlate = registrationPlate;
        if (icon is not null && Icon?.Equals(icon) is not true) Icon = icon;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        if (vehicleTypeId.HasValue && vehicleTypeId.Value != Guid.Empty && !VehicleTypeId.Equals(vehicleTypeId.Value)) VehicleTypeId = vehicleTypeId.Value;
        if (companyId.HasValue && companyId.Value != Guid.Empty && !CompanyId.Equals(companyId.Value)) CompanyId = companyId.Value;

        if (seatLimit.HasValue && !SeatLimit.Equals(seatLimit.Value)) SeatLimit = seatLimit.Value;
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;
        return this;
    }
}