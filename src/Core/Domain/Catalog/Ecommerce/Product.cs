namespace TD.CitizenAPI.Domain.Catalog;

public class Product : AuditableEntity, IAggregateRoot
{
    public string UserName { get; set; } = default!;
    public Guid? CompanyId { get; set; }
    public int Type { get; set; } = 1;
    public string Name { get;  set; } = default!;
    public string? Code { get; set; }
    public string? SKU { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; private set; }
    public string? ShortDescription { get; set; }

    public decimal Rate { get;  set; } = decimal.Zero;
    public string? ImagePath { get;  set; }
    public string? Image { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Images { get; set; }
    public string? VideoURL { get; set; }

    //GIa ban thuc te Giá bán phải lớn hơn 0 và phải nhỏ hơn hoặc bằng Giá niêm yết và không được nhỏ hơn 10% giá trị của Giá niêm yết
    public int Price { get; set; } = 0;
    //Gia niem yet
    public int ListPrice { get; set; } = 0;
    //So luong
    public int Quantity { get; set; } = 0;

    //
    //Danh muc san pham
    public Guid? PrimaryEcommerceCategoryId { get; set; }

    public Guid? BrandId { get;  set; }

    public int Status { get; set; } = 1;
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }

    public virtual Company? Company { get; set; }
    public virtual Brand? Brand { get;  set; }
    public virtual Area? Province { get; set; }
    public virtual Area? District { get; set; }
    public virtual Area? Commune { get; set; }

    public virtual EcommerceCategory? PrimaryEcommerceCategory { get; set; }
    public virtual ICollection<AttributeDatetime>? AttributeDatetimes { get; set; } 

    public virtual ICollection<AttributeDecimal>? AttributeDecimals { get; set; }

    public virtual ICollection<AttributeInt>? AttributeInts { get; set; }

    public virtual ICollection<AttributeText>? AttributeTexts { get; set; }
    public virtual ICollection<AttributeBoolean>? AttributeBooleans { get; set; }
    public virtual ICollection<AttributeVarchar>? AttributeVarchars { get; set; }

    public virtual ICollection<EcommerceCategoryProduct> EcommerceCategoryProducts { get; set; } = new List<EcommerceCategoryProduct>();

    public Product(string userName, Guid? companyId, int type, string name, string? code, string? sKU, string? barcode, string? description, string? shortDescription, decimal rate, string? imagePath, string? image, string? thumbnailUrl, string? images, string? videoURL, int price, int listPrice, int quantity, Guid? primaryEcommerceCategoryId, Guid? brandId, int status, DateTime? fromDate, DateTime? toDate, string? phoneNumber, string? address, Guid? provinceId, Guid? districtId, Guid? communeId)
    {
        UserName = userName;
        CompanyId = companyId;
        Type = type;
        Name = name;
        Code = code;
        SKU = sKU;
        Barcode = barcode;
        Description = description;
        ShortDescription = shortDescription;
        Rate = rate;
        ImagePath = imagePath;
        Image = image;
        ThumbnailUrl = thumbnailUrl;
        Images = images;
        VideoURL = videoURL;
        Price = price;
        ListPrice = listPrice;
        Quantity = quantity;
        PrimaryEcommerceCategoryId = primaryEcommerceCategoryId;
        BrandId = brandId;
        Status = status;
        FromDate = fromDate;
        ToDate = toDate;
        PhoneNumber = phoneNumber;
        Address = address;
        ProvinceId = provinceId;
        DistrictId = districtId;
        CommuneId = communeId;
    }

    public Product Update(string? userName, Guid? companyId, int? type, string? name, string? code, string? sKU, string? barcode, string? description, string? shortDescription, decimal? rate, string? imagePath, string? image, string? thumbnailUrl, string? images, string? videoURL, int? price, int? listPrice, int? quantity, Guid? primaryEcommerceCategoryId, Guid? brandId, int? status, DateTime? fromDate, DateTime? toDate, string? phoneNumber, string? address, Guid? provinceId, Guid? districtId, Guid? communeId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (rate.HasValue && Rate != rate) Rate = rate.Value;
        if (brandId.HasValue && brandId.Value != Guid.Empty && !BrandId.Equals(brandId.Value)) BrandId = brandId.Value;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;

        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (companyId.HasValue && companyId.Value != Guid.Empty && !CompanyId.Equals(companyId.Value)) CompanyId = companyId.Value;
        if (type.HasValue && Type != type) Type = type.Value;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (sKU is not null && SKU?.Equals(sKU) is not true) SKU = sKU;
        if (barcode is not null && Barcode?.Equals(barcode) is not true) Barcode = barcode;
        if (shortDescription is not null && ShortDescription?.Equals(shortDescription) is not true) ShortDescription = shortDescription;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (thumbnailUrl is not null && ThumbnailUrl?.Equals(thumbnailUrl) is not true) ThumbnailUrl = thumbnailUrl;
        if (images is not null && Images?.Equals(images) is not true) Images = images;
        if (videoURL is not null && VideoURL?.Equals(videoURL) is not true) VideoURL = videoURL;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        if (price.HasValue && Price != price) Price = price.Value;
        if (listPrice.HasValue && ListPrice != listPrice) ListPrice = listPrice.Value;
        if (quantity.HasValue && Quantity != quantity) Quantity = quantity.Value;
        if (status.HasValue && Status != status) Status = status.Value;
        if (fromDate.HasValue && FromDate != fromDate) FromDate = fromDate.Value;
        if (toDate.HasValue && ToDate != toDate) ToDate = toDate.Value;
        if (phoneNumber is not null && PhoneNumber?.Equals(phoneNumber) is not true) PhoneNumber = phoneNumber;
        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (primaryEcommerceCategoryId.HasValue && primaryEcommerceCategoryId.Value != Guid.Empty && !PrimaryEcommerceCategoryId.Equals(primaryEcommerceCategoryId.Value)) PrimaryEcommerceCategoryId = primaryEcommerceCategoryId.Value;
        if (provinceId.HasValue && provinceId.Value != Guid.Empty && !ProvinceId.Equals(provinceId.Value)) ProvinceId = provinceId.Value;
        if (districtId.HasValue && districtId.Value != Guid.Empty && !DistrictId.Equals(districtId.Value)) DistrictId = districtId.Value;
        if (communeId.HasValue && communeId.Value != Guid.Empty && !CommuneId.Equals(communeId.Value)) CommuneId = communeId.Value;

        return this;
    }

    public Product ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }
}