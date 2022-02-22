namespace TD.CitizenAPI.Application.Catalog.Areas;

public class AreasByParentCodeSpec : Specification<Area>, ISingleResultSpecification
{
    public AreasByParentCodeSpec(string? parentCode) =>
         Query.Where(p => p.ParentCode == parentCode);

}