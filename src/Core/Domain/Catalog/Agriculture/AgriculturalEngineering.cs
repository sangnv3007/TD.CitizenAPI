namespace TD.CitizenAPI.Domain.Catalog;

public class AgriculturalEngineering : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public Guid? AgriculturalEngineeringCategoryId { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public int ViewQuantity { get; set; } = 0;

    public AgriculturalEngineeringCategory? AgriculturalEngineeringCategory { get; set; }

    public AgriculturalEngineering(string name, Guid? agriculturalEngineeringCategoryId, string? code, string? image, string? content, string? description)
    {
        Name = name;
        AgriculturalEngineeringCategoryId = agriculturalEngineeringCategoryId;
        Code = code;
        Image = image;
        Content = content;
        Description = description;
    }

    public AgriculturalEngineering Update(string name, Guid? agriculturalEngineeringCategoryId, string code, string? image, string? content, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (agriculturalEngineeringCategoryId.HasValue && agriculturalEngineeringCategoryId.Value != Guid.Empty && !AgriculturalEngineeringCategoryId.Equals(agriculturalEngineeringCategoryId.Value))
            AgriculturalEngineeringCategoryId = agriculturalEngineeringCategoryId.Value;
        return this;
    }
}