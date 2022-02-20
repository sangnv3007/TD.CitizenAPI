using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class MarketProductsBySearchRequestSpec : EntitiesByPaginationFilterSpec<MarketProduct, MarketProductDto>
{
    public MarketProductsBySearchRequestSpec(SearchMarketProductsRequest request)
        : base(request) =>
        Query
            .Include(p => p.MarketCategory)
            .Where(p => p.MarketCategoryId.Equals(request.MarketCategoryId!.Value), request.MarketCategoryId.HasValue);

}