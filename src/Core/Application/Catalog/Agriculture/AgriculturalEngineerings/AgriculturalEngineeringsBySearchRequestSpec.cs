using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class AgriculturalEngineeringsBySearchRequestSpec : EntitiesByPaginationFilterSpec<AgriculturalEngineering, AgriculturalEngineeringDto>
{
    public AgriculturalEngineeringsBySearchRequestSpec(SearchAgriculturalEngineeringsRequest request)
        : base(request) =>
        Query
            .Include(p => p.AgriculturalEngineeringCategory)
            .Where(p => p.AgriculturalEngineeringCategoryId.Equals(request.AgriculturalEngineeringCategoryId!.Value), request.AgriculturalEngineeringCategoryId.HasValue);

}