namespace TD.CitizenAPI.Domain.Catalog;

//Dien dan doanh nghiep nha dau tu - Danh muc
public class EnterpriseForumCategory : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }

    public EnterpriseForumCategory(string name, string? code, string? icon, string? image, string? description)
    {
        Name = name;
        Code = code;
        Icon = icon;
        Image = image;
        Description = description;
    }

    public EnterpriseForumCategory Update(string? name, string? code, string? icon, string? image, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (icon is not null && Icon?.Equals(icon) is not true) Icon = icon;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}