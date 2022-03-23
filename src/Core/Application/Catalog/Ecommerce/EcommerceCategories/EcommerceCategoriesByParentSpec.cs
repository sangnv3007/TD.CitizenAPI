namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class EcommerceCategoriesByParentSpec : Specification<EcommerceCategory>, ISingleResultSpecification
{
    public EcommerceCategoriesByParentSpec(Guid? id) =>
        Query.Where(p => p.ParentId == id);

}