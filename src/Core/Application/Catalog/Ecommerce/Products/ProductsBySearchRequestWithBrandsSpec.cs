namespace TD.CitizenAPI.Application.Catalog.Products;

public class ProductsBySearchRequestWithBrandsSpec : EntitiesByPaginationFilterSpec<Product, CategoriesInProduct>
{
    public ProductsBySearchRequestWithBrandsSpec(SearchProductsRequest request)
        : base(request) =>
        Query
            .Include(p => p.Brand)
        .Include(p => p.Company)
        .Include(p => p.Province)
        .Include(p => p.District)
        .Include(p => p.Commune)
        .Include(p => p.PrimaryEcommerceCategory)
        .OrderBy(c => c.Name, !request.HasOrderBy())
        .Where(p => p.BrandId.Equals(request.BrandId!.Value), request.BrandId.HasValue)
        .Where(p => p.CompanyId.Equals(request.CompanyId!.Value), request.CompanyId.HasValue)
        .Where(p => p.ProvinceId.Equals(request.ProvinceId!.Value), request.ProvinceId.HasValue)
        .Where(p => p.DistrictId.Equals(request.DistrictId!.Value), request.DistrictId.HasValue)
        .Where(p => p.CommuneId.Equals(request.CommuneId!.Value), request.CommuneId.HasValue)
        .Where(p => p.Type == request.Type, request.Type.HasValue)
        .Where(p => p.Status == request.Status, request.Status.HasValue)
        .Where(p => p.PrimaryEcommerceCategoryId.Equals(request.PrimaryEcommerceCategoryId!.Value), request.PrimaryEcommerceCategoryId.HasValue)
        .Where(e => e.EcommerceCategoryProducts.Any(x => x.EcommerceCategoryId == request.EcommerceCategoryId), request.EcommerceCategoryId.HasValue)

        .Where(p => p.UserName == request.UserName, !string.IsNullOrWhiteSpace(request.UserName))
        .Where(p => p.Price >= request.PriceFrom!.Value, request.PriceFrom.HasValue)
        .Where(p => p.Price <= request.PriceTo!.Value, request.PriceTo.HasValue)

        .Where(p => p.Rate >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
        .Where(p => p.Rate <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
}