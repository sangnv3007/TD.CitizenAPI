namespace TD.CitizenAPI.Application.Catalog.AreaInfors;

public class AreaInforByAreaCodeSpec : Specification<AreaInfor>, ISingleResultSpecification
{
    public AreaInforByAreaCodeSpec(string areaCode) =>
        Query.Where(b => b.AreaCode == areaCode);
}