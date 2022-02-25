using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class AttributeByCodeSpec : Specification<Attribute>, ISingleResultSpecification
{
    public AttributeByCodeSpec(string Code) =>
        Query.Where(p => p.Code == Code);
}