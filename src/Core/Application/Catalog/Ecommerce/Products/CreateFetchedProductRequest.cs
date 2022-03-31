using TD.CitizenAPI.Application.Catalog.Attributes;
using TD.CitizenAPI.Application.Catalog.EcommerceCategories;
using TD.CitizenAPI.Domain.Common.Events;
using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Products;

public class CreateFetchedProductRequest : IRequest<Guid>
{
    public string? UserName { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? SKU { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get;  set; }
    public string? ShortDescription { get; set; }

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
    public Guid? BrandId { get;  set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }

    public string Category { get; set; } = default!;
    public virtual ICollection<string>? Categories { get; set; }


}

public class CreateFetchedProductRequestValidator : CustomValidator<Product>
{
    public CreateFetchedProductRequestValidator(IReadRepository<Product> repository, IStringLocalizer<CreateFetchedProductRequestValidator> localizer) =>
        RuleFor(p => p.Code)
            .NotEmpty()
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new ProductByCodeSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["product.alreadyexists"], name));
}

public class CreateFetchedProductRequestHandler : IRequestHandler<CreateFetchedProductRequest, Guid>
{
    private readonly IRepository<Product> _repository;
    private readonly IRepository<EcommerceCategory> _repositoryEcommerceCategory;

    private readonly ICurrentUser _currentUser;

    private readonly IFileStorageService _file;

    public CreateFetchedProductRequestHandler(
        IRepository<Product> repository,
        IFileStorageService file,
        IRepository<EcommerceCategory> repositoryEcommerceCategory,
        ICurrentUser currentUser)
    {
        (_repository, _file, _repositoryEcommerceCategory, _currentUser) = (repository, file, repositoryEcommerceCategory, currentUser);
    }

    public async Task<Guid> Handle(CreateFetchedProductRequest request, CancellationToken cancellationToken)
    {
        //string productImagePath = await _file.UploadAsync<Product>(request.Image, FileType.Image, cancellationToken);

        var item = await _repository.GetBySpecAsync(new ProductByCodeSpec(request.Code), cancellationToken);
        if (item!=null)
        {
            throw new NotFoundException("product.alreadyexists");
        }

        var product = new Product(request.UserName ?? _currentUser.GetUserName(), null, 1, request.Name, request.Code, request.SKU, request.Barcode, request.Description, request.ShortDescription, 0, request.ImagePath, request.Image, request.ThumbnailUrl, request.Images, request.VideoURL, request.Price, request.ListPrice, request.Quantity, null, request.BrandId, 1, null, null, request.PhoneNumber, request.Address, request.ProvinceId, request.DistrictId, request.CommuneId)
        {
           
        };

        var category = await _repositoryEcommerceCategory.GetBySpecAsync(new EcommerceCategoriesByIconSpec(request.Category), cancellationToken);

        if (request.Categories != null && request.Categories.Count > 0)
        {
            foreach (string? categoryItem in request.Categories)
            {
                var categoryTmp = await _repositoryEcommerceCategory.GetBySpecAsync(new EcommerceCategoriesByIconSpec(categoryItem), cancellationToken);
                if (categoryTmp != null)
                {
                    bool isPrimary = false;
                    if (category != null && category.Id == categoryTmp.Id)
                    {
                        isPrimary = true;
                        product.PrimaryEcommerceCategoryId = category.Id;
                    }

                    product.EcommerceCategoryProducts.Add(new EcommerceCategoryProduct(categoryTmp.Id, product, isPrimary));
                }
            }
        }

        // Add Domain Events to be raised after the commit
        product.DomainEvents.Add(EntityCreatedEvent.WithEntity(product));

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;
    }

   
}