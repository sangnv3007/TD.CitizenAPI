namespace TD.CitizenAPI.Domain.Catalog;

public class ProductReview : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }
    public Guid? ProductId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Rate { get; set; } = 0;
    public string? Images { get; set; }
    public int Like { get; set; } = 0;

    public virtual Product? Product { get; set; }

    public ProductReview(string? userName, Guid? productId, string? title, string? content, int rate, string? images, int like)
    {
        UserName = userName;
        ProductId = productId;
        Title = title;
        Content = content;
        Rate = rate;
        Images = images;
        Like = like;
    }
}