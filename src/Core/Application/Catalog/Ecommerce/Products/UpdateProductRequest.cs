using TD.CitizenAPI.Application.Catalog.Attributes;
using TD.CitizenAPI.Domain.Catalog;
using TD.CitizenAPI.Domain.Common.Events;
using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Products;

public class UpdateProductRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public Guid? CompanyId { get; set; }
    public int Type { get; set; } = 1;
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? SKU { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }

    public decimal Rate { get; set; } = decimal.Zero;
    public string? ImagePath { get; private set; }
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

    public Guid? BrandId { get; set; }

    public int Status { get; set; } = 1;
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }

    public virtual ICollection<Guid>? Categories { get; set; }
    public virtual ICollection<AttributeValueInProduct>? Attributes { get; set; }
}

public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, Guid>
{
    private readonly IRepository<Product> _repository;
    private readonly IStringLocalizer<UpdateProductRequestHandler> _localizer;
    private readonly IFileStorageService _file;
    private readonly IRepository<AttributeBoolean> _repositoryAttributeBoolean;
    private readonly IRepository<AttributeDatetime> _repositoryAttributeDatetime;
    private readonly IRepository<AttributeDecimal> _repositoryAttributeDecimal;
    private readonly IRepository<AttributeInt> _repositoryAttributeInt;
    private readonly IRepository<AttributeText> _repositoryAttributeText;
    private readonly IRepository<AttributeVarchar> _repositoryAttributeVarchar;
    private readonly IRepository<Attribute> _repositoryAttribute;
    private readonly IRepository<EcommerceCategoryProduct> _repositoryEcommerceCategoryProduct;

    public UpdateProductRequestHandler(
        IRepository<Product> repository,
        IStringLocalizer<UpdateProductRequestHandler> localizer,
        IFileStorageService file,
        IRepository<Attribute> repositoryAttribute,
        IRepository<AttributeBoolean> repositoryAttributeBoolean,
        IRepository<AttributeDatetime> repositoryAttributeDatetime,
        IRepository<AttributeDecimal> repositoryAttributeDecimal,
        IRepository<AttributeInt> repositoryAttributeInt,
        IRepository<AttributeText> repositoryAttributeText,
        IRepository<EcommerceCategoryProduct> repositoryEcommerceCategoryProduct,
        IRepository<AttributeVarchar> repositoryAttributeVarchar) =>
        (_repository, _file, _repositoryAttribute, _repositoryAttributeBoolean, _repositoryAttributeDatetime, _repositoryAttributeDecimal, _repositoryAttributeInt, _repositoryAttributeText, _repositoryAttributeVarchar, _localizer, _repositoryEcommerceCategoryProduct) = (repository, file, repositoryAttribute, repositoryAttributeBoolean, repositoryAttributeDatetime, repositoryAttributeDecimal, repositoryAttributeInt, repositoryAttributeText, repositoryAttributeVarchar, localizer, repositoryEcommerceCategoryProduct);

    public async Task<Guid> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
       /* var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = product ?? throw new NotFoundException(string.Format(_localizer["product.notfound"], request.Id));*/

        var product = await _repository.GetBySpecAsync(
          new ProductByIdWithoutSpec(request.Id), cancellationToken)
       ?? throw new NotFoundException(string.Format(_localizer["product.notfound"], request.Id));

        var updatedProduct = product.Update(request.UserName, request.CompanyId, request.Type, request.Name, request.Code, request.SKU, request.Barcode, request.Description, request.ShortDescription, request.Rate, request.ImagePath, request.Image, request.ThumbnailUrl, request.Images, request.VideoURL, request.Price, request.ListPrice, request.Quantity, request.PrimaryEcommerceCategoryId, request.BrandId, request.Status, request.FromDate, request.ToDate, request.PhoneNumber, request.Address, request.ProvinceId, request.DistrictId, request.CommuneId);


#pragma warning disable CS8602 // Dereference of a possibly null reference.
      

        await _repositoryEcommerceCategoryProduct.DeleteRangeAsync(product.EcommerceCategoryProducts);
        product.EcommerceCategoryProducts.Clear();
#pragma warning restore CS8602 // Dereference of a possibly null reference.


        if (request.Categories != null && request.Categories.Count > 0)
        {
            for (int i = 0; i < request.Categories.Count; i++)
            {
                bool isPrimary = false;
                if (i == request.Categories.Count - 1)
                {
                    isPrimary = true;
                    product.PrimaryEcommerceCategoryId = request.Categories.ElementAt(i);
                }


                product.EcommerceCategoryProducts.Add(new EcommerceCategoryProduct(request.Categories.ElementAt(i), product, isPrimary));
            }
        }

        product.AttributeDatetimes?.Clear();
        product.AttributeDecimals?.Clear();
        product.AttributeInts?.Clear();
        product.AttributeVarchars?.Clear();
        product.AttributeBooleans?.Clear();
        product.AttributeTexts?.Clear();

        product.AttributeDatetimes = new List<AttributeDatetime>();
        product.AttributeDecimals = new List<AttributeDecimal>();
        product.AttributeInts = new List<AttributeInt>();
        product.AttributeVarchars = new List<AttributeVarchar>();
        product.AttributeBooleans = new List<AttributeBoolean>();
        product.AttributeTexts = new List<AttributeText>();

        if (request.Attributes != null)
        {
            foreach (var tmp in request.Attributes)
            {
                await HandleAttribute(product, tmp);
            }
        }



        // Add Domain Events to be raised after the commit
        product.DomainEvents.Add(EntityUpdatedEvent.WithEntity(product));

        await _repository.UpdateAsync(updatedProduct, cancellationToken);

        return request.Id;
    }

    public async Task HandleAttribute(Product product, AttributeValueInProduct value)
    {
        try
        {

            var attribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByCodeSpec(value.Code));
            if (attribute != null)
            {
                var attributeId = attribute.Id;

                switch (attribute.DataType)
                {
                    case "Varchar":
                        AttributeVarchar attributeVarchar = new AttributeVarchar(Convert.ToString(value.Value), attributeId, product.Id);
                        product.AttributeVarchars.Add(attributeVarchar);
                        break;
                    case "Text":
                        AttributeText
                            attributeText = new AttributeText(Convert.ToString(value.Value), attributeId, product.Id);
                        product.AttributeTexts.Add(attributeText);

                        break;
                    case "Decimal":
                        AttributeDecimal attributeDecimal = new AttributeDecimal(decimal.Parse(value.Value.ToString()), attributeId, product.Id);
                        product.AttributeDecimals.Add(attributeDecimal);

                        break;
                    case "Int":
                        AttributeInt attributeInt = new AttributeInt(Convert.ToInt32(value.Value.ToString()), attributeId, product.Id);
                        product.AttributeInts.Add(attributeInt);

                        break;
                    case "Boolean":
                        AttributeBoolean attributeBoolean = new AttributeBoolean((bool)value.Value, attributeId, product.Id);
                        product.AttributeBooleans.Add(attributeBoolean);
                        break;
                    case "Datetime":
                        AttributeDatetime attributeDatetime = new AttributeDatetime(System.DateTime.Parse(value.Value.ToString()), attributeId, product.Id);
                        product.AttributeDatetimes.Add(attributeDatetime);

                        break;
                    default:
                        break;
                }
            }


        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
        }


    }
}