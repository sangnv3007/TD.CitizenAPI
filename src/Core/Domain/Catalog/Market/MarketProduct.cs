namespace TD.CitizenAPI.Domain.Catalog;

public class MarketProduct : AuditableEntity, IAggregateRoot
{
    public Guid? MarketCategoryId { get; set; }
    public string Name { get; set; }
    public string? Packaging { get; set; }
    public int Price { get; set; }
    public string? Brand { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Unit { get; set; }
    public string? Origin { get; set; }
    public string? Description { get; set; }
    public string? DisplayUnit { get; set; }
    public string? DisplayFactor { get; set; }
    public virtual MarketCategory? MarketCategory { get; set; }

    public MarketProduct(Guid? marketCategoryId, string name, string? packaging, int price, string? brand, string? code, string? image, string? unit, string? origin, string? description, string? displayUnit, string? displayFactor)
    {
        MarketCategoryId = marketCategoryId;
        Name = name;
        Packaging = packaging;
        Price = price;
        Brand = brand;
        Code = code;
        Image = image;
        Unit = unit;
        Origin = origin;
        Description = description;
        DisplayUnit = displayUnit;
        DisplayFactor = displayFactor;
    }

    public MarketProduct Update(Guid? marketCategoryId, string? name, string? packaging, int? price, string? brand, string? code, string? image, string? unit, string? origin, string? description, string? displayUnit, string? displayFactor)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (price.HasValue && Price != price) Price = price.Value;
        if (packaging is not null && Packaging?.Equals(packaging) is not true) Packaging = packaging;
        if (brand is not null && Brand?.Equals(brand) is not true) Brand = brand;
        if (unit is not null && Unit?.Equals(unit) is not true) Unit = unit;
        if (origin is not null && Origin?.Equals(origin) is not true) Origin = origin;
        if (displayUnit is not null && DisplayUnit?.Equals(displayUnit) is not true) DisplayUnit = displayUnit;
        if (displayFactor is not null && DisplayFactor?.Equals(displayFactor) is not true) DisplayFactor = displayFactor;
        if (marketCategoryId.HasValue && marketCategoryId.Value != Guid.Empty && !MarketCategoryId.Equals(marketCategoryId.Value)) MarketCategoryId = marketCategoryId.Value;

        return this;
    }
}