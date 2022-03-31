using System.ComponentModel;

namespace TD.CitizenAPI.Application.Catalog.Products;

public interface IProductsGeneratorJob : IScopedService
{
    [DisplayName("Generate Random Brand example job on Queue notDefault")]
    Task GenerateAsync(string category, int page, int limit, string sortOption, CancellationToken cancellationToken);

}