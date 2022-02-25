namespace TD.CitizenAPI.Domain.Catalog;

public class EcommerceCategoryProduct : AuditableEntity, IAggregateRoot
{
    public Guid? EcommerceCategoryId { get; set; }
    public Guid? ProductId { get; set; }
    public bool IsPrimary { get; set; } = false;
    public virtual Product? Product { get; set; }
    public EcommerceCategory? EcommerceCategory { get; set; }

    public EcommerceCategoryProduct(Guid? ecommerceCategoryId, Guid? productId, bool isPrimary)
    {
        EcommerceCategoryId = ecommerceCategoryId;
        ProductId = productId;
        IsPrimary = isPrimary;
    }
    public EcommerceCategoryProduct(Guid? ecommerceCategoryId, Product? product, bool isPrimary)
    {
        EcommerceCategoryId = ecommerceCategoryId;
        Product = product;
        IsPrimary = isPrimary;
    }
}