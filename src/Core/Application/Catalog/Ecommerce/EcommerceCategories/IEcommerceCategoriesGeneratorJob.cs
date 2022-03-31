using System.ComponentModel;


namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public interface IEcommerceCategoriesGeneratorJob : IScopedService
{
    [DisplayName("Generate Random Brand example job on Queue notDefault")]
    Task GenerateAsync(int nSeed, string token, CancellationToken cancellationToken);

}