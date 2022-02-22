namespace TD.CitizenAPI.Application.Catalog.Places;

public class PlacesByAreaSpec : Specification<Place>
{
    public PlacesByAreaSpec(Guid areaId) =>
        Query.Where(p => p.ProvinceId == areaId || p.DistrictId == areaId || p.CommuneId == areaId);
}
