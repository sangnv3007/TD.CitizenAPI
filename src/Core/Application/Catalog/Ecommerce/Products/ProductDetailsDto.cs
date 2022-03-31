using TD.CitizenAPI.Application.Catalog.Areas;
using TD.CitizenAPI.Application.Catalog.Attributes;
using TD.CitizenAPI.Application.Catalog.Brands;
using TD.CitizenAPI.Application.Catalog.Companies;
using TD.CitizenAPI.Application.Catalog.EcommerceCategories;

namespace TD.CitizenAPI.Application.Catalog.Products;

public class ProductDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public Guid? CompanyId { get; set; }
    public int Type { get; set; } = 1;
    public string Name { get;  set; } = default!;
    public string? Code { get; set; }
    public string? SKU { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
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
    public DateTime? CreatedOn { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }

    public virtual CompanyDto? Company { get; set; }
    public virtual BrandDto? Brand { get;  set; }
    public virtual AreaDto? Province { get; set; }
    public virtual AreaDto? District { get; set; }
    public virtual AreaDto? Commune { get; set; }

    public virtual EcommerceCategoryDto? PrimaryEcommerceCategory { get; set; }
    public virtual List<Guid>? Categories { get; set; }
    public virtual ICollection<AttributeValueInProductResponse>? Attributes { get; set; }

    public virtual ICollection<AttributeDatetimeDto>? AttributeDatetimes { get; set; }

    public virtual ICollection<AttributeDecimalDto>? AttributeDecimals { get; set; }

    public virtual ICollection<AttributeIntDto>? AttributeInts { get; set; }

    public virtual ICollection<AttributeTextDto>? AttributeTexts { get; set; }
    public virtual ICollection<AttributeBooleanDto>? AttributeBooleans { get; set; }
    public virtual ICollection<AttributeVarcharDto>? AttributeVarchars { get; set; }
}