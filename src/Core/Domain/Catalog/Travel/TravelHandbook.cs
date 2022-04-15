namespace TD.CitizenAPI.Domain.Catalog;

public class TravelHandbook : AuditableEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; } 
    public int ViewQuantity { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public string? Tags { get; set; }

    public TravelHandbook(string? name, string? content, string? description, int viewQuantity, string? image, string? source, string? tags)
    {
        Name = name;
        Content = content;
        Description = description;
        ViewQuantity = viewQuantity;
        Image = image;
        Source = source;
        Tags = tags;
    }

    public TravelHandbook Update(string? name, string? content, string? description,  string? image, string? source, string? tags)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (source is not null && Source?.Equals(source) is not true) Source = source;
        if (tags is not null && Tags?.Equals(tags) is not true) Tags = tags;

        return this;
    }
    public TravelHandbook Update(int viewQuantity)
    {
        ViewQuantity = viewQuantity;
        return this;
    }
}