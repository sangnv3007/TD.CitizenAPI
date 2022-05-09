namespace TD.CitizenAPI.Domain.Catalog;

//Danh muc benh
public class Disease : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }

    public Disease(string name, string? code, string? image, string? images, string? description, string? content)
    {
        Name = name;
        Code = code;
        Image = image;
        Images = images;
        Description = description;
        Content = content;
    }

    public Disease Update(string? name, string? code, string? image, string? images, string? description, string? content)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (images is not null && Images?.Equals(images) is not true) Images = images;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}