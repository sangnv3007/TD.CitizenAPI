namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class SearchMarketProductsRequest : PaginationFilter, IRequest<PaginationResponse<MarketProductDto>>
{
    public Guid? MarketCategoryId { get; set; }

}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchMarketProductsRequest, PaginationResponse<MarketProductDto>>
{
    private readonly IReadRepository<MarketProduct> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<MarketProduct> repository) => _repository = repository;

    public async Task<PaginationResponse<MarketProductDto>> Handle(SearchMarketProductsRequest request, CancellationToken cancellationToken)
    {
        var spec = new MarketProductsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<MarketProductDto>(list, count, request.PageNumber, request.PageSize);
    }
}