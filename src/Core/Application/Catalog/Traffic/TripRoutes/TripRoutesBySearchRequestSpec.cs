using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.TripRoutes;

public class TripRoutesBySearchRequestSpec : EntitiesByPaginationFilterSpec<TripRoute, TripRouteDto>
{
    public TripRoutesBySearchRequestSpec(SearchTripRoutesRequest request)
        : base(request) =>
        Query
        .Include(p => p.Province)
        .Include(p => p.District)
        .Include(p => p.Commune)
        .Include(p => p.Trip)
        .Where(p => p.TripId.Equals(request.TripId!.Value), request.TripId.HasValue)
        ;

}