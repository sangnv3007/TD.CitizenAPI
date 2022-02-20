namespace TD.CitizenAPI.Application.Catalog.Hotlines;

public class HotlineByIdWithIncludeSpec : Specification<Hotline, HotlineDetailsDto>, ISingleResultSpecification
{
    public HotlineByIdWithIncludeSpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.HotlineCategoryId);
}