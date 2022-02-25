namespace TD.CitizenAPI.Domain.Catalog;

public class ProductSaved : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }

    public Guid? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public ProductSaved(string? userName, Guid? productId)
    {
        UserName = userName;
        ProductId = productId;
    }

}