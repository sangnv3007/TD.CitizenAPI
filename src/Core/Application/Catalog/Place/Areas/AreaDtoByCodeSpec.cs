namespace TD.CitizenAPI.Application.Catalog.Areas;

public class AreaDtoByCodeSpec : Specification<Area, AreaDto>, ISingleResultSpecification
{
    public AreaDtoByCodeSpec(string? code) =>
        Query.Where(p => p.Code == code, !string.IsNullOrEmpty(code));

}