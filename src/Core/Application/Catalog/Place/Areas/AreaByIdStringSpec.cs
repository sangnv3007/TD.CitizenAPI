using System.Text.RegularExpressions;

namespace TD.CitizenAPI.Application.Catalog.Areas;

public class AreaByIdStringSpec : Specification<Area, AreaDto>, ISingleResultSpecification
{
    public AreaByIdStringSpec(string? id)
    {
        Guid idGuid = Guid.Empty;
        Guid.TryParse(id, out idGuid);
        Query.Where(p => p.Id == idGuid);
        }

}