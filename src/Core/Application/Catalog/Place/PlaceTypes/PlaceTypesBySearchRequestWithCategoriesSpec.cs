namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class PlaceTypesBySearchRequestWithCategoriesSpec : EntitiesByPaginationFilterSpec<PlaceType, PlaceTypeDto>
{
    public PlaceTypesBySearchRequestWithCategoriesSpec(SearchPlaceTypesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Category)
            .OrderBy(c => c.Name, !request.HasOrderBy())
            .Where(p => p.Category.Code == (request.CategoryCode), !string.IsNullOrWhiteSpace(request.CategoryCode))
            .Where(p => p.CategoryId.Equals(request.CategoryId!.Value), request.CategoryId.HasValue);
}