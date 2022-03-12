using System.Globalization;

namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class CarpoolsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Carpool, CarpoolDto>
{
    public CarpoolsBySearchRequestSpec(SearchCarpoolsRequest request)
        : base(request)
    {
        DateTime? departureDateStart = null;
        if (!string.IsNullOrWhiteSpace(request.DepartureDateStart))
        {
            try
            {
                departureDateStart = DateTime.ParseExact(request.DepartureDateStart, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

            }
        }

        DateTime? departureDateEnd = null;
        if (!string.IsNullOrWhiteSpace(request.DepartureDateEnd)) {
            try
            {
                departureDateStart = DateTime.ParseExact(request.DepartureDateEnd, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

            }
        }

        Query
            .Include(p => p.VehicleType)
            .Include(p => p.DepartureProvince)
            .Include(p => p.DepartureDistrict)
            .Include(p => p.DepartureCommune)
            .Include(p => p.ArrivalProvince)
            .Include(p => p.ArrivalCommune)
            .Include(p => p.ArrivalDistrict)
            .Where(p => p.VehicleTypeId.Equals(request.VehicleTypeId!.Value), request.VehicleTypeId.HasValue)
            .Where(p => p.DepartureProvinceId.Equals(request.DepartureProvinceId!.Value), request.DepartureProvinceId.HasValue)
            .Where(p => p.DepartureDistrictId.Equals(request.DepartureDistrictId!.Value), request.DepartureDistrictId.HasValue)
            .Where(p => p.DepartureCommuneId.Equals(request.DepartureCommuneId!.Value), request.DepartureCommuneId.HasValue)
            .Where(p => p.ArrivalProvinceId.Equals(request.ArrivalProvinceId!.Value), request.ArrivalProvinceId.HasValue)
            .Where(p => p.ArrivalDistrictId.Equals(request.ArrivalDistrictId!.Value), request.ArrivalDistrictId.HasValue)
            .Where(p => p.ArrivalCommuneId.Equals(request.ArrivalCommuneId!.Value), request.ArrivalCommuneId.HasValue)
            .Where(p => p.Status.Equals(request.Status!.Value), request.Status.HasValue)
            .Where(p => p.UserName == request.UserName, !string.IsNullOrWhiteSpace(request.UserName))
            .Where(p => p.Role == request.Role, !string.IsNullOrWhiteSpace(request.Role))
            .Where(p => p.Price >= request.PriceFrom!.Value, request.PriceFrom.HasValue)
            .Where(p => p.Price <= request.PriceTo!.Value, request.PriceTo.HasValue)
            .Where(p => p.DepartureDate >= departureDateStart, departureDateStart.HasValue)
            .Where(p => p.DepartureDate <= departureDateEnd, departureDateEnd.HasValue)
            ;
    }

}