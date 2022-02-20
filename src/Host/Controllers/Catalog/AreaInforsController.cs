using TD.CitizenAPI.Application.Catalog.AreaInfors;
using TD.CitizenAPI.Application.Catalog.Areas;
using TD.CitizenAPI.Application.Catalog.Categories;
using TD.CitizenAPI.Application.Catalog.PlaceTypes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class AreaInforsController : VersionedApiController
{

    [HttpGet("{code}")]
    [OpenApiOperation("Get category details.", "")]
    public Task<Result<AreaInforDetailsDto>> GetAsync(string code)
    {
        return Mediator.Send(new GetAreaInforRequest(code));
    }

}