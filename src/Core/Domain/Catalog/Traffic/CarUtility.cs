namespace TD.CitizenAPI.Domain.Catalog;

public class CarUtility : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }

    public CarUtility(string name, string? code, string? icon, string? description)
    {
        Name = name;
        Code = code;
        Icon = icon;
        Description = description;
    }

    public CarUtility Update(string? name, string? code, string? icon, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (icon is not null && Icon?.Equals(icon) is not true) Icon = icon;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        return this;
    }
}