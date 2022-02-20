namespace TD.CitizenAPI.Application.Catalog.AreaInforValues;

public class AreaInforValueByAreaInforSpec : Specification<AreaInforValue>, ISingleResultSpecification
{
    public AreaInforValueByAreaInforSpec(Guid areaInforId) =>
        Query.Where(b => b.AreaInforId == areaInforId);
}