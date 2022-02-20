namespace TD.CitizenAPI.Domain.Catalog;

public class Area : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string? ParentCode { get; set; }
    public string? Slug { get; set; }
    public string? Type { get; set; }
    public int Level { get; set; }
    public string? NameWithType { get; set; }
    public string? Path { get; set; }
    public string? PathWithType { get; set; }
    public string? Description { get; set; }

    public Area(string name, string code, string? parentCode, string? slug, string? type, int level, string? nameWithType, string? path, string? pathWithType, string? description)
    {
        Name = name;
        Code = code;
        ParentCode = parentCode;
        Slug = slug;
        Type = type;
        Level = level;
        NameWithType = nameWithType;
        Path = path;
        PathWithType = pathWithType;
        Description = description;
    }

    public Area(string name, string code, string? parentCode, string? type, int level, string? description)
    {
        Name = name;
        Code = code;
        ParentCode = parentCode;
        Type = type;
        Level = level;
        Description = description;
    }

    public Area Update(string? name, string? code, string? parentCode, string? slug, string? type, int? level, string? nameWithType, string? path, string? pathWithType, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (parentCode is not null && ParentCode?.Equals(parentCode) is not true) ParentCode = parentCode;
        if (slug is not null && Slug?.Equals(slug) is not true) Slug = slug;
        if (type is not null && Type?.Equals(type) is not true) Type = type;
        if (level.HasValue && level > -1 && !Level.Equals(level.Value)) Level = level.Value;

        if (nameWithType is not null && NameWithType?.Equals(nameWithType) is not true) NameWithType = nameWithType;
        if (path is not null && Path?.Equals(path) is not true) Path = path;
        if (pathWithType is not null && PathWithType?.Equals(pathWithType) is not true) PathWithType = pathWithType;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}