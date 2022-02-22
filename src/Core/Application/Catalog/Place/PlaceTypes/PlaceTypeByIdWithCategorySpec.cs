namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class PlaceTypeByIdWithCategorySpec : Specification<PlaceType, PlaceTypeDetailsDto>, ISingleResultSpecification
{
    public PlaceTypeByIdWithCategorySpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Category);
}