namespace TD.CitizenAPI.Domain.Catalog;

public class EcommerceCategory : AuditableEntity, IAggregateRoot
{
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public int? Position { get; set; }
    public bool? IncludeInMenu { get; set; }
    public int? Level { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string[]? Tags { get; set; }
    public int? Status { get; set; }
    public bool? IsActive { get; set; }

    public virtual EcommerceCategory? Parent { get; set; }

    public virtual ICollection<Product>? PrimaryProducts { get; set; }
    public virtual ICollection<EcommerceCategoryAttribute>? EcommerceCategoryAttributes { get; set; }
    public virtual ICollection<EcommerceCategoryProduct>? EcommerceCategoryProducts { get; set; }


    public EcommerceCategory(Guid? parentId, string name, string? slug, string? description, string? metaTitle, string? metaDescription, int? position, bool? includeInMenu, int? level, string? icon, string? image, string[]? tags, int? status, bool? isActive)
    {
        ParentId = parentId;
        Name = name;
        Slug = slug;
        Description = description;
        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        Position = position;
        IncludeInMenu = includeInMenu;
        Level = level;
        Icon = icon;
        Image = image;
        Tags = tags;
        Status = status;
        IsActive = isActive;
    }

    public EcommerceCategory()
    {
    }

    public EcommerceCategory Update(Guid? parentId, string? name, string? slug, string? description, string? metaTitle, string? metaDescription, int? position, bool? includeInMenu, int? level, string? icon, string? image, string[]? tags, int? status, bool? isActive)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (slug is not null && Slug?.Equals(slug) is not true) Slug = slug;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (metaTitle is not null && MetaTitle?.Equals(metaTitle) is not true) MetaTitle = metaTitle;
        if (metaDescription is not null && MetaDescription?.Equals(metaDescription) is not true) MetaDescription = metaDescription;
        if (slug is not null && Slug?.Equals(slug) is not true) Slug = slug;
        if (icon is not null && Icon?.Equals(icon) is not true) Icon = icon;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        if (parentId.HasValue && parentId.Value != Guid.Empty && !ParentId.Equals(parentId.Value)) ParentId = parentId.Value;
        if (position.HasValue && !Position.Equals(position.Value)) Position = position.Value;
        if (includeInMenu.HasValue && !IncludeInMenu.Equals(includeInMenu.Value)) IncludeInMenu = includeInMenu.Value;
        if (level.HasValue && !Level.Equals(level.Value)) Level = level.Value;
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;
        if (isActive.HasValue && !IsActive.Equals(isActive.Value)) IsActive = isActive.Value;
        if (tags != null) Tags = tags;

        return this;
    }
}