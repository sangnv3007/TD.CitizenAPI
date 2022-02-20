namespace TD.CitizenAPI.Application.Catalog.Hotlines;

public class HotlineByHotlineCategorySpec : Specification<Hotline>
{
    public HotlineByHotlineCategorySpec(Guid hotlineCategoryId) =>
        Query.Where(p => p.HotlineCategoryId == hotlineCategoryId);
}
