using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.Trips;

public class TripsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Trip, TripDto>
{
    public TripsBySearchRequestSpec(SearchTripsRequest request)
        : base(request) =>
        Query
        .Include(p => p.DepartureProvince)
        .Include(p => p.DepartureDistrict)
        .Include(p => p.DepartureCommune)
        .Include(p => p.ArrivalProvince)
        .Include(p => p.ArrivalDistrict)
        .Include(p => p.ArrivalCommune)
        .Where(p => p.VehicleId.Equals(request.VehicleId!.Value), request.VehicleId.HasValue)
        .Where(p => p.DepartureProvinceId.Equals(request.AreaDepartureId!.Value) || p.DepartureDistrictId.Equals(request.AreaDepartureId!.Value) || p.DepartureCommuneId.Equals(request.AreaDepartureId!.Value), request.AreaDepartureId.HasValue)
        .Where(p => p.ArrivalProvinceId.Equals(request.AreaDepartureId!.Value) || p.ArrivalDistrictId.Equals(request.AreaDepartureId!.Value) || p.ArrivalCommuneId.Equals(request.AreaDepartureId!.Value), request.AreaDepartureId.HasValue).Where(p => p.TimeStart.CompareTo(request.TimeStartFrom) >=0, !string.IsNullOrEmpty(request.TimeStartFrom)).Where(p => p.TimeStart.CompareTo(request.TimeStartTo) >= 0, !string.IsNullOrEmpty(request.TimeStartTo))
        ;

}