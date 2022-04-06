namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class AgriculturalEngineeringByIdWithIncludeSpec : Specification<AgriculturalEngineering, AgriculturalEngineeringDetailsDto>, ISingleResultSpecification
{
    public AgriculturalEngineeringByIdWithIncludeSpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.AgriculturalEngineeringCategory);
}