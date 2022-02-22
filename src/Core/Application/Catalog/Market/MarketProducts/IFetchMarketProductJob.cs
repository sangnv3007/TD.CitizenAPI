using System.ComponentModel;

namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public interface IFetchMarketProductJob : IScopedService
{
    [DisplayName("Fetch MarketProduct")]
    Task FetchProductAsync(CancellationToken cancellationToken);

   
}