namespace TD.CitizenAPI.Domain.Catalog;

//Thong tin thi truong lao dong
public class LaborMarketInformation : AuditableEntity, IAggregateRoot
{
    public string Title { get; set; }
    public string? Actor { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public int? ViewQuantity { get; set; }

    public LaborMarketInformation(string title, string? actor, string? content, DateTime? date, string? image, string? source, int? viewQuantity)
    {
        Title = title;
        Actor = actor;
        Content = content;
        Date = date;
        Image = image;
        Source = source;
        ViewQuantity = viewQuantity;
    }

    public LaborMarketInformation Update(string? title, string? actor, string? content, DateTime? date, string? image, string? source, int? viewQuantity)
    {
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (actor is not null && Actor?.Equals(actor) is not true) Actor = actor;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (source is not null && Source?.Equals(source) is not true) Source = source;
        if (date.HasValue && !Date.Equals(date.Value)) Date = date.Value;
        if (viewQuantity.HasValue && ViewQuantity != viewQuantity) ViewQuantity = viewQuantity.Value;
        return this;
    }
}