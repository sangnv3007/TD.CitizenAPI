namespace TD.CitizenAPI.Domain.Catalog;

public class Carpool : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string? Description { get; set; }
    //Diem khoi hanh
    public string? DeparturePlaceName { get; set; }
    public double? DepartureLatitude { get; set; }
    public double? DepartureLongitude { get; set; }
    public Guid? DepartureProvinceId { get; set; }
    public Guid? DepartureDistrictId { get; set; }
    public Guid? DepartureCommuneId { get; set; }

    //Diem den
    public string? ArrivalPlaceName { get; set; }
    public double? ArrivalLatitude { get; set; }
    public double? ArrivalLongitude { get; set; }
    public Guid? ArrivalProvinceId { get; set; }
    public Guid? ArrivalDistrictId { get; set; }
    public Guid? ArrivalCommuneId { get; set; }

    public DateTime? DepartureDate { get; set; }
    public TimeSpan? DepartureTime { get; set; }
    public string? DepartureTimeText { get; set; }
    //Loai phuong tien
    public Guid? VehicleTypeId { get; set; }
    //Vai tro
    public string? Role { get; set; }
    //Gia
    public decimal Price { get; set; }
    //So ghe
    public int SeatCount { get; set; }
    //Trang thai
    public int Status { get; set; }

    public virtual VehicleType? VehicleType { get; set; }
    public virtual Area? ArrivalProvince { get; set; }
    public virtual Area? ArrivalDistrict { get; set; }
    public virtual Area? ArrivalCommune { get; set; }
    public virtual Area? DepartureProvince { get; set; }
    public virtual Area? DepartureDistrict { get; set; }
    public virtual Area? DepartureCommune { get; set; }

    public Carpool(string name, string? phoneNumber, string userName, string? description, string? departurePlaceName, double? departureLatitude, double? departureLongitude, Guid? departureProvinceId, Guid? departureDistrictId, Guid? departureCommuneId, string? arrivalPlaceName, double? arrivalLatitude, double? arrivalLongitude, Guid? arrivalProvinceId, Guid? arrivalDistrictId, Guid? arrivalCommuneId, DateTime? departureDate, TimeSpan? departureTime, string? departureTimeText, Guid? vehicleTypeId, string? role, decimal price, int seatCount, int status)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        UserName = userName;
        Description = description;
        DeparturePlaceName = departurePlaceName;
        DepartureLatitude = departureLatitude;
        DepartureLongitude = departureLongitude;
        DepartureProvinceId = departureProvinceId;
        DepartureDistrictId = departureDistrictId;
        DepartureCommuneId = departureCommuneId;
        ArrivalPlaceName = arrivalPlaceName;
        ArrivalLatitude = arrivalLatitude;
        ArrivalLongitude = arrivalLongitude;
        ArrivalProvinceId = arrivalProvinceId;
        ArrivalDistrictId = arrivalDistrictId;
        ArrivalCommuneId = arrivalCommuneId;
        DepartureDate = departureDate;
        DepartureTime = departureTime;
        DepartureTimeText = departureTimeText;
        VehicleTypeId = vehicleTypeId;
        Role = role;
        Price = price;
        SeatCount = seatCount;
        Status = status;
    }

    public Carpool Update(string? name, string? phoneNumber, string? userName, string? description, string? departurePlaceName, double? departureLatitude, double? departureLongitude, Guid? departureProvinceId, Guid? departureDistrictId, Guid? departureCommuneId, string? arrivalPlaceName, double? arrivalLatitude, double? arrivalLongitude, Guid? arrivalProvinceId, Guid? arrivalDistrictId, Guid? arrivalCommuneId, DateTime? departureDate, TimeSpan? departureTime, string? departureTimeText, Guid? vehicleTypeId, string? role, decimal? price, int? seatCount, int? status)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (phoneNumber is not null && PhoneNumber?.Equals(phoneNumber) is not true) PhoneNumber = phoneNumber;
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (role is not null && Role?.Equals(role) is not true) Role = role;
        if (departureTimeText is not null && DepartureTimeText?.Equals(departureTimeText) is not true) DepartureTimeText = departureTimeText;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        if (departurePlaceName is not null && DeparturePlaceName?.Equals(departurePlaceName) is not true) DeparturePlaceName = departurePlaceName;

        if (departureProvinceId.HasValue && departureProvinceId.Value != Guid.Empty && !DepartureProvinceId.Equals(departureProvinceId.Value)) DepartureProvinceId = departureProvinceId.Value;
        if (departureDistrictId.HasValue && departureDistrictId.Value != Guid.Empty && !DepartureDistrictId.Equals(departureDistrictId.Value)) DepartureDistrictId = departureDistrictId.Value;
        if (departureCommuneId.HasValue && departureCommuneId.Value != Guid.Empty && !DepartureCommuneId.Equals(departureCommuneId.Value)) DepartureCommuneId = departureCommuneId.Value;
        if (departureLatitude.HasValue && !DepartureLatitude.Equals(departureLatitude.Value)) DepartureLatitude = departureLatitude.Value;
        if (departureLongitude.HasValue && !DepartureLongitude.Equals(departureLongitude.Value)) DepartureLongitude = departureLongitude.Value;

        if (arrivalPlaceName is not null && ArrivalPlaceName?.Equals(arrivalPlaceName) is not true) ArrivalPlaceName = arrivalPlaceName;
        if (arrivalProvinceId.HasValue && arrivalProvinceId.Value != Guid.Empty && !ArrivalProvinceId.Equals(arrivalProvinceId.Value)) ArrivalProvinceId = arrivalProvinceId.Value;
        if (arrivalDistrictId.HasValue && arrivalDistrictId.Value != Guid.Empty && !ArrivalDistrictId.Equals(arrivalDistrictId.Value)) ArrivalDistrictId = arrivalDistrictId.Value;
        if (arrivalCommuneId.HasValue && arrivalCommuneId.Value != Guid.Empty && !ArrivalCommuneId.Equals(arrivalCommuneId.Value)) ArrivalCommuneId = arrivalCommuneId.Value;
        if (arrivalLatitude.HasValue && !ArrivalLatitude.Equals(arrivalLatitude.Value)) ArrivalLatitude = arrivalLatitude.Value;
        if (arrivalLongitude.HasValue && !ArrivalLongitude.Equals(arrivalLongitude.Value)) ArrivalLongitude = arrivalLongitude.Value;

        if (vehicleTypeId.HasValue && vehicleTypeId.Value != Guid.Empty && !VehicleTypeId.Equals(vehicleTypeId.Value)) VehicleTypeId = vehicleTypeId.Value;

        if (departureDate.HasValue && !DepartureDate.Equals(departureDate.Value)) DepartureDate = departureDate.Value;
        if (departureTime.HasValue && !DepartureTime.Equals(departureTime.Value)) DepartureTime = departureTime.Value;
        if (seatCount.HasValue && !SeatCount.Equals(seatCount.Value)) SeatCount = seatCount.Value;
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;
        if (price.HasValue && !Price.Equals(price.Value)) Price = price.Value;

        return this;
    }

    public Carpool Update( int? status)
    {
  
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;

        return this;
    }
}