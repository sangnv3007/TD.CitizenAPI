namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class PlaceTypeByNameSpec : Specification<PlaceType>, ISingleResultSpecification
{
    public PlaceTypeByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}