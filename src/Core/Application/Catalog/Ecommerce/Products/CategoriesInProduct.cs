using TD.CitizenAPI.Application.Catalog.EcommerceCategories;

namespace TD.CitizenAPI.Application.Catalog.Products;

public class CategoriesInProduct : IDto
{
    public Guid Id { get; set; }
    public bool IsPrimary { get; set; }
    public EcommerceCategoryWithChildDto? EcommerceCategory { get; set; }

}