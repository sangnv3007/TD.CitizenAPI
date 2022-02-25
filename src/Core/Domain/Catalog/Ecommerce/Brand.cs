namespace TD.CitizenAPI.Domain.Catalog;

public class Brand : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? Code { get; set; }
    public string? Image { get; set; }

    public Brand(string name, string? description, string? code, string? image)
    {
        Name = name;
        Description = description;
        Code = code;
        Image = image;
    }

    public Brand Update(string? name, string? description, string? code, string? image)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}