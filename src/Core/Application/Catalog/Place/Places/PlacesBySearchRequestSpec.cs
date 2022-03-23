namespace TD.CitizenAPI.Application.Catalog.Places;

public class PlacesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Place, PlaceDto>
{
    public PlacesBySearchRequestSpec(SearchPlacesRequest request)
        : base(request) =>
        Query
            .Include(p => p.PlaceType)
            .Include(p => p.District)
            .Include(p => p.Province)
            .Include(p => p.Commune)
            .OrderBy(c => c.PlaceName, !request.HasOrderBy())
            .Where(p => request.PlaceTypeIds.Contains(p.PlaceTypeId!.Value.ToString()), !string.IsNullOrEmpty(request.PlaceTypeIds))
            .Where(p => p.ProvinceId.Equals(request.ProvinceId!.Value), request.ProvinceId.HasValue)
            .Where(p => p.DistrictId.Equals(request.DistrictId!.Value), request.DistrictId.HasValue)
            .Where(p => p.CommuneId.Equals(request.CommuneId!.Value), request.CommuneId.HasValue)
            .Where(p => p.ProvinceId.Equals(request.AreaId!.Value) || p.DistrictId.Equals(request.AreaId!.Value) || p.CommuneId.Equals(request.AreaId!.Value), request.AreaId.HasValue)
            .Where(x => Math.Acos(Math.Sin((double)(Math.PI * x.Latitude / 180)) * Math.Sin((double)(Math.PI * request.Latitude / 180)) + Math.Cos((double)(Math.PI * x.Latitude / 180)) * Math.Cos((double)(Math.PI * request.Latitude / 180)) * Math.Cos((double)(Math.PI / 180 * (x.Longitude - request.Longitude))) - 0.000001) * 180 / Math.PI * 60 * 1.1515 * 1.609344 < request.Range, request.Range.HasValue && request.Longitude.HasValue && request.Latitude.HasValue);
}