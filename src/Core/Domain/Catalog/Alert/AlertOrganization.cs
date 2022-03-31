namespace TD.CitizenAPI.Domain.Catalog;

public class AlertOrganization : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }

    public AlertOrganization(string name, string? code, string? image, string? description)
    {
        Name = name;
        Code = code;
        Image = image;
        Description = description;
    }

    public AlertOrganization Update(string? name, string? code,  string? image,  string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}