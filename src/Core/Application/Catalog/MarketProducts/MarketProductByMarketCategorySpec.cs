namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class MarketProductByMarketCategorySpec : Specification<MarketProduct>
{
    public MarketProductByMarketCategorySpec(Guid marketCategoryId) =>
        Query.Where(p => p.MarketCategoryId == marketCategoryId);
}
