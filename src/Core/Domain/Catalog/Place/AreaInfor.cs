namespace TD.CitizenAPI.Domain.Catalog;

public class AreaInfor : AuditableEntity, IAggregateRoot
{
    public string AreaCode { get; set; }
    public string? Introduce { get; set; }
    public string? Acreage { get; set; }
    public string? Population { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }

    public AreaInfor(string areaCode, string? introduce, string? acreage, string? population, string? image, string? images)
    {
        AreaCode = areaCode;
        Introduce = introduce;
        Acreage = acreage;
        Population = population;
        Image = image;
        Images = images;
    }

    public AreaInfor Update(string? areaCode, string? introduce, string? acreage, string? population, string? image, string? images)
    {
        if (areaCode is not null && AreaCode?.Equals(areaCode) is not true) AreaCode = areaCode;
        if (introduce is not null && Introduce?.Equals(introduce) is not true) Introduce = introduce;
        if (acreage is not null && Acreage?.Equals(acreage) is not true) Acreage = acreage;
        if (population is not null && Population?.Equals(population) is not true) Population = population;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (images is not null && Images?.Equals(images) is not true) Images = images;

        return this;
    }
}