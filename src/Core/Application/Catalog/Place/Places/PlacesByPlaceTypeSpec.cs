namespace TD.CitizenAPI.Application.Catalog.Places;

public class PlacesByPlaceTypeSpec : Specification<Place>
{
    public PlacesByPlaceTypeSpec(Guid placeTypeId) =>
        Query.Where(p => p.PlaceTypeId == placeTypeId);
}
