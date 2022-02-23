using TD.CitizenAPI.Application.Catalog.Vehicles;

namespace TD.CitizenAPI.Application.Catalog.Trips;

public class TripDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public Guid? VehicleId { get; set; }
    public VehicleDto? Vehicle { get; set; }

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

}