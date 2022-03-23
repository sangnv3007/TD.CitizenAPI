namespace TD.CitizenAPI.Application.Catalog.AreaInforValues;

public class AreaInforValuesByCodeSpec : Specification<AreaInforValue>, ISingleResultSpecification
{
    public AreaInforValuesByCodeSpec(Guid id) =>
        Query.Where(p => p.AreaInforId == id);
}