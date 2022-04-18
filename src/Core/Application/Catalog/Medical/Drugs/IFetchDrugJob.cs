using System.ComponentModel;

namespace TD.CitizenAPI.Application.Catalog.Drugs;

public interface IFetchDrugJob : IScopedService
{
    [DisplayName("Fetch Drug")]
    Task FetchDrugAsync(CancellationToken cancellationToken);
   
}