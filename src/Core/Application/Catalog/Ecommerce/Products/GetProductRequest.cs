using Mapster;
using TD.CitizenAPI.Application.Catalog.Attributes;
using TD.CitizenAPI.Application.Catalog.EcommerceCategories;
using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Products;

public class GetProductRequest : IRequest<Result<ProductDetailsDto>>
{
    public Guid Id { get; set; }

    public GetProductRequest(Guid id) => Id = id;
}

public class GetProductRequestHandler : IRequestHandler<GetProductRequest, Result<ProductDetailsDto>>
{
    private readonly IRepository<Product> _repository;
    private readonly IRepository<EcommerceCategory> _repositoryEcommerceCategory;
    private readonly IRepository<Attribute> _repositoryAttribute;

    private readonly IStringLocalizer<GetProductRequestHandler> _localizer;

    public GetProductRequestHandler(
        IRepository<Product> repository,
        IRepository<EcommerceCategory> repositoryEcommerceCategory,
        IRepository<Attribute> repositoryAttribute,
        IStringLocalizer<GetProductRequestHandler> localizer) =>
        (_repository, _repositoryEcommerceCategory, _repositoryAttribute, _localizer) = (repository, repositoryEcommerceCategory, repositoryAttribute, localizer);

    public async Task<Result<ProductDetailsDto>> Handle(GetProductRequest request, CancellationToken cancellationToken) {

        var product = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException(string.Format(_localizer["product.notfound"], request.Id));

        var mappedProduct = product.Adapt<ProductDetailsDto>();

        Guid? categoryPrimary = product.PrimaryEcommerceCategoryId;
        List<CategoriesInProduct> categories = new List<CategoriesInProduct>();
        List<AttributeValueInProductResponse> attributes = new List<AttributeValueInProductResponse>();


        foreach (var category in product.EcommerceCategoryProducts)
        {

            var item = await _repositoryEcommerceCategory.GetByIdAsync(category.EcommerceCategoryId, cancellationToken);
            var mapped = item.Adapt<EcommerceCategoryDto>();

            categories.Add(new CategoriesInProduct { Id = (Guid)category.EcommerceCategoryId, IsPrimary = category.IsPrimary, EcommerceCategory = mapped });
        }


        categories.OrderBy(p => p.Id);


        foreach (var item in product.AttributeDatetimes)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByCodeSpec(item.Attribute.Code), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = item.Attribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeDecimals)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByCodeSpec(item.Attribute.Code), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = item.Attribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeInts)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByCodeSpec(item.Attribute.Code), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = item.Attribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeVarchars)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByCodeSpec(item.Attribute.Code), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = item.Attribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeBooleans)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByCodeSpec(item.Attribute.Code), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = item.Attribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeTexts)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByCodeSpec(item.Attribute.Code), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = item.Attribute.Code, Value = item.Value, Attribute = mapped });
        }

        mappedProduct.Attributes = attributes;
        mappedProduct.Categories = categories;

        return Result<ProductDetailsDto>.Success(mappedProduct);
    }
}