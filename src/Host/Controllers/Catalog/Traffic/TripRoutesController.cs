using TD.CitizenAPI.Application.Catalog.TripRoutes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class TripRoutesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách địa điểm đón trả của chuyến xe.", "")]
    public Task<PaginationResponse<TripRouteDto>> SearchAsync(SearchTripRoutesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết địa điểm đón trả khách của chuyến xe.", "")]
    public Task<Result<TripRouteDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetTripRouteRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới địa điểm đón trả khách của chuyến xe.", "")]
    public Task<Result<Guid>> CreateAsync(CreateTripRouteRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Chỉnh sửa địa điểm đón trả khách của chuyến xe.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTripRouteRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa địa điểm đón trả khách của chuyến xe.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteTripRouteRequest(id));
    }

}