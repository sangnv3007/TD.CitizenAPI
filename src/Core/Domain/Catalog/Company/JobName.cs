namespace TD.CitizenAPI.Domain.Catalog;

public class JobName : AuditableEntity, IAggregateRoot
{
    //Do tuoi
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    public JobName(string name, string? code, string? description)
    {
        Name = name;
        Code = code;
        Description = description;
    }

    public JobName Update(string? name, string? code,  string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        return this;
    }
}