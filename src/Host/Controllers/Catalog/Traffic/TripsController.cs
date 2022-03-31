using TD.CitizenAPI.Application.Catalog.Trips;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class TripsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách chuyến xe.", "")]
    public Task<PaginationResponse<TripDto>> SearchAsync(SearchTripsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết chuyến xe.", "")]
    public Task<Result<TripDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetTripRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới chuyến xe.", "")]
    public Task<Result<Guid>> CreateAsync(CreateTripRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật chuyến xe.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTripRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa chuyến xe.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteTripRequest(id));
    }

}