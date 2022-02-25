namespace TD.CitizenAPI.Application.Catalog.Products;

public class ProductByIdWithBrandSpec : Specification<Product, ProductDetailsDto>, ISingleResultSpecification
{
    public ProductByIdWithBrandSpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Brand)
        .Include(p => p.Company)
        .Include(p => p.Province)
        .Include(p => p.District)
        .Include(p => p.Commune)
        .Include(p => p.PrimaryEcommerceCategory)
        ;
}