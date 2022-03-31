namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class EcommerceCategoriesByIconSpec : Specification<EcommerceCategory>, ISingleResultSpecification
{
    public EcommerceCategoriesByIconSpec(string icon) =>
        Query.Where(p => p.Icon == icon);

}