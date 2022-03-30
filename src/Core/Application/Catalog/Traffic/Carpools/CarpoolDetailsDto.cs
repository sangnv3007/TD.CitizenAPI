using TD.CitizenAPI.Application.Catalog.Areas;
using TD.CitizenAPI.Application.Catalog.VehicleTypes;

namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class CarpoolDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string UserName { get; set; } = default!;
    public string? Description { get; set; }

    /// <summary>
    /// Diem khoi hanh
    /// </summary>
    public string? DeparturePlaceName { get; set; }
    public double? DepartureLatitude { get; set; }
    public double? DepartureLongitude { get; set; }

    /// <summary>
    /// Diem den
    /// </summary>
    public string? ArrivalPlaceName { get; set; }
    public double? ArrivalLatitude { get; set; }
    public double? ArrivalLongitude { get; set; }

    public DateTime? DepartureDate { get; set; }
    public TimeSpan? DepartureTime { get; set; }
    public string? DepartureTimeText { get; set; }
    //Loai phuong tien
    //Vai tro
    public string? Role { get; set; }
    //Gia
    public decimal Price { get; set; }
    //So ghe
    public int SeatCount { get; set; }
    //Trang thai
    public int Status { get; set; }

    public Guid? DepartureProvinceId { get; set; }
    public Guid? DepartureDistrictId { get; set; }
    public Guid? DepartureCommuneId { get; set; }

    //Diem den
   
    public Guid? ArrivalProvinceId { get; set; }
    public Guid? ArrivalDistrictId { get; set; }
    public Guid? ArrivalCommuneId { get; set; }
    public Guid? VehicleTypeId { get; set; }

    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }

    public virtual VehicleTypeDto? VehicleType { get; set; }
    public virtual AreaDto? ArrivalProvince { get; set; }
    public virtual AreaDto? ArrivalDistrict { get; set; }
    public virtual AreaDto? ArrivalCommune { get; set; }
    public virtual AreaDto? DepartureProvince { get; set; }
    public virtual AreaDto? DepartureDistrict { get; set; }
    public virtual AreaDto? DepartureCommune { get; set; }
}