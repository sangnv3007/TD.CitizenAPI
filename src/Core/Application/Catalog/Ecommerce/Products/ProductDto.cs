using TD.CitizenAPI.Application.Catalog.Areas;
using TD.CitizenAPI.Application.Catalog.Attributes;
using TD.CitizenAPI.Application.Catalog.Brands;
using TD.CitizenAPI.Application.Catalog.Companies;
using TD.CitizenAPI.Application.Catalog.EcommerceCategories;

namespace TD.CitizenAPI.Application.Catalog.Products;

public class ProductDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; } 
    public Guid? CompanyId { get; set; }
    public int Type { get; set; } = 1;
    public string? Name { get;  set; }
    public string? Code { get; set; }


    public decimal Rate { get;  set; } = decimal.Zero;
    public string? Image { get; set; }

    //GIa ban thuc te Giá bán phải lớn hơn 0 và phải nhỏ hơn hoặc bằng Giá niêm yết và không được nhỏ hơn 10% giá trị của Giá niêm yết
    public int Price { get; set; } = 0;
    //Gia niem yet
    public int ListPrice { get; set; } = 0;
    //So luong
    public int Quantity { get; set; } = 0;
    public int Status { get; set; } = 1;
    public string? PhoneNumber { get; set; }

   
}