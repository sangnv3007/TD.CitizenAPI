namespace TD.CitizenAPI.Domain.Catalog;

public class Trip : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }

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

    //Gia ve
    public int? Price { get; set; }
    //Thoi gian xuat phat
    public string? TimeStart { get; set; }
    public string? Frequency { get; set; }
    //Thoi gian du kien cua chuyen di
    public int? Duration { get; set; }
    public bool? Status { get; set; }


    public virtual Area? ArrivalProvince { get; set; }
    public virtual Area? ArrivalDistrict { get; set; }
    public virtual Area? ArrivalCommune { get; set; }
    public virtual Area? DepartureProvince { get; set; }
    public virtual Area? DepartureDistrict { get; set; }
    public virtual Area? DepartureCommune { get; set; }

    public Trip(string name, string? description, Guid? vehicleId, string? departurePlaceName, double? departureLatitude, double? departureLongitude, Guid? departureProvinceId, Guid? departureDistrictId, Guid? departureCommuneId, string? arrivalPlaceName, double? arrivalLatitude, double? arrivalLongitude, Guid? arrivalProvinceId, Guid? arrivalDistrictId, Guid? arrivalCommuneId, int? price, string? timeStart, string? frequency, int? duration, bool? status)
    {
        Name = name;
        Description = description;
        VehicleId = vehicleId;
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
        Price = price;
        TimeStart = timeStart;
        Frequency = frequency;
        Duration = duration;
        Status = status;
    }

    public Trip Update(string? name, string? description, Guid? vehicleId, string? departurePlaceName, double? departureLatitude, double? departureLongitude, Guid? departureProvinceId, Guid? departureDistrictId, Guid? departureCommuneId, string? arrivalPlaceName, double? arrivalLatitude, double? arrivalLongitude, Guid? arrivalProvinceId, Guid? arrivalDistrictId, Guid? arrivalCommuneId, int? price, string? timeStart, string? frequency, int? duration, bool? status)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (frequency is not null && Frequency?.Equals(frequency) is not true) Frequency = frequency;
        if (timeStart is not null && TimeStart?.Equals(timeStart) is not true) TimeStart = timeStart;
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

        if (vehicleId.HasValue && vehicleId.Value != Guid.Empty && !VehicleId.Equals(vehicleId.Value)) VehicleId = vehicleId.Value;

        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;
        if (price.HasValue && !Price.Equals(price.Value)) Price = price.Value;
        if (duration.HasValue && !Duration.Equals(duration.Value)) Duration = duration.Value;

        return this;
    }
}