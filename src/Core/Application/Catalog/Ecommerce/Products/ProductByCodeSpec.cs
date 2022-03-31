namespace TD.CitizenAPI.Application.Catalog.Products;

public class ProductByCodeSpec : Specification<Product>, ISingleResultSpecification
{
    public ProductByCodeSpec(string code) =>
        Query.Where(b => b.Code == code);
}