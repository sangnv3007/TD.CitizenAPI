namespace TD.CitizenAPI.Application.Catalog.Products;

public class SearchProductsRequest : PaginationFilter, IRequest<PaginationResponse<ProductDto>>
{
    public Guid? BrandId { get; set; }
    public Guid? EcommerceCategoryId { get; set; }
    public Guid? PrimaryEcommerceCategoryId { get; set; }
    public Guid? CompanyId { get; set; }
    public int? Status { get; set; }
    public int? Type { get; set; }
    public int? PriceFrom { get; set; }
    public int? PriceTo { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? CommuneId { get; set; }

    public string? UserName { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchProductsRequestHandler : IRequestHandler<SearchProductsRequest, PaginationResponse<ProductDto>>
{
    private readonly IReadRepository<Product> _repository;

    public SearchProductsRequestHandler(IReadRepository<Product> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductDto>> Handle(SearchProductsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductsBySearchRequestWithBrandsSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProductDto>(list, count, request.PageNumber, request.PageSize);
    }
}