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

public class ProductByIdSpec : Specification<Product, ProductDetailsDto>, ISingleResultSpecification
{
    public ProductByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id).
        Include(p => p.Brand)
        .Include(p => p.Commune)
        .Include(p => p.Province)
        .Include(p => p.District)
        .Include(p => p.Company)
        .Include(p => p.PrimaryEcommerceCategory)
        .Include(p => p.AttributeBooleans)
        .Include(p => p.AttributeDatetimes)
        .Include(p => p.AttributeDecimals)
        .Include(p => p.AttributeInts)
        .Include(p => p.AttributeTexts)
        .Include(p => p.AttributeVarchars)

        ;
}

public class ProductByIdWithoutSpec : Specification<Product>, ISingleResultSpecification
{
    public ProductByIdWithoutSpec(Guid id) =>
        Query.Where(p => p.Id == id).
        Include(p => p.Brand)
        .Include(p => p.Commune)
        .Include(p => p.Province)
        .Include(p => p.District)
        .Include(p => p.Company)
        .Include(p => p.PrimaryEcommerceCategory)
        .Include(p => p.AttributeBooleans)
        .Include(p => p.AttributeDatetimes)
        .Include(p => p.AttributeDecimals)
        .Include(p => p.AttributeInts)
        .Include(p => p.AttributeTexts)
        .Include(p => p.AttributeVarchars)
        .Include(p => p.EcommerceCategoryProducts)

        ;
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

      
        var product = await _repository.GetBySpecAsync(
           (ISpecification<Product, ProductDetailsDto>)new ProductByIdSpec(request.Id), cancellationToken)
       ?? throw new NotFoundException(string.Format(_localizer["product.notfound"], request.Id));


        List<Guid> ids = new List<Guid>();
        var parentId = product.PrimaryEcommerceCategoryId;
        while (parentId != null)
        {
            ids.Add((Guid)parentId);
            var itemParent = await _repositoryEcommerceCategory.GetBySpecAsync(
           (ISpecification<EcommerceCategory, EcommerceCategoryDetailsDto>)new EcommerceCategoryByIdSpec((Guid)parentId), cancellationToken);
            if (itemParent != null)
            {
                parentId = itemParent.ParentId;
            }
        }

        ids.Reverse();
        product.Categories = ids;


        List<AttributeValueInProductResponse> attributes = new List<AttributeValueInProductResponse>();



        foreach (var item in product.AttributeDatetimes)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByIdSpec((DefaultIdType)item.AttributeId), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = itemAttribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeDecimals)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByIdSpec((DefaultIdType)item.AttributeId), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = itemAttribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeInts)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByIdSpec((DefaultIdType)item.AttributeId), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = itemAttribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeVarchars)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByIdSpec((DefaultIdType)item.AttributeId), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = itemAttribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeBooleans)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByIdSpec((DefaultIdType)item.AttributeId), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = itemAttribute.Code, Value = item.Value, Attribute = mapped });
        }

        foreach (var item in product.AttributeTexts)
        {
            var itemAttribute = await _repositoryAttribute.GetBySpecAsync(new AttributeByIdSpec((DefaultIdType)item.AttributeId), cancellationToken);
            var mapped = itemAttribute.Adapt<AttributeDto>();
            attributes.Add(new AttributeValueInProductResponse { Code = itemAttribute.Code, Value = item.Value, Attribute = mapped });
        }

        product.Attributes = attributes;

        return Result<ProductDetailsDto>.Success(product);
    }
}