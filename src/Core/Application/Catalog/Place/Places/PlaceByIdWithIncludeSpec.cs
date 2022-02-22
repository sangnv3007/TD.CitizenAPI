namespace TD.CitizenAPI.Application.Catalog.Places;

public class PlaceByIdWithIncludeSpec : Specification<Place, PlaceDetailsDto>, ISingleResultSpecification
{
    public PlaceByIdWithIncludeSpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.PlaceType)
            .Include(p => p.Province)
            .Include(p => p.District)
            .Include(p => p.Commune);
}