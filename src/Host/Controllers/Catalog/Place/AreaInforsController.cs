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

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Result<Guid>> CreateAsync(CreateAreaInforRequest request)
    {
        return Mediator.Send(request);
    }

   

}