namespace TD.CitizenAPI.Application.Catalog.Areas;

public class AreaByCodeSpec : Specification<Area>, ISingleResultSpecification
{
    public AreaByCodeSpec(string? code) =>
        Query.Where(p => p.Code.Equals(code), code is not null);

}