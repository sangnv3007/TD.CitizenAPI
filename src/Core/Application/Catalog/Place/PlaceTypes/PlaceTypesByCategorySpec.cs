namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class PlaceTypesByCategorySpec : Specification<PlaceType>
{
    public PlaceTypesByCategorySpec(Guid categoryId) =>
        Query.Where(p => p.CategoryId == categoryId);
}
