using TD.CitizenAPI.Application.Catalog.AreaInfors;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class AreaInforsController : VersionedApiController
{
    //[ApiVersion("2.0")]

    [HttpGet("{code}")]
    [OpenApiOperation("Get category details.", "")]
    public Task<Result<AreaInforDetailsDto>> GetAsync(string code)
    {
        return Mediator.Send(new GetAreaInforRequest(code));
    }

}