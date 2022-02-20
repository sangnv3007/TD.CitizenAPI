namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class MarketProductByIdWithIncludeSpec : Specification<MarketProduct, MarketProductDetailsDto>, ISingleResultSpecification
{
    public MarketProductByIdWithIncludeSpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.MarketCategory);
}