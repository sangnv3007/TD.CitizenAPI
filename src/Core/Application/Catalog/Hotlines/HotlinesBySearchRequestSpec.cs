using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.Hotlines;

public class HotlinesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Hotline, HotlineDto>
{
    public HotlinesBySearchRequestSpec(SearchHotlinesRequest request)
        : base(request) =>
        Query
            .Include(p => p.HotlineCategory)
            .Where(p => p.HotlineCategoryId.Equals(request.HotlineCategoryId!.Value), request.HotlineCategoryId.HasValue);

}