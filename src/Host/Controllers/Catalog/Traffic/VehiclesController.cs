using TD.CitizenAPI.Application.Catalog.Vehicles;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class VehiclesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách phương tiện.", "")]
    public Task<PaginationResponse<VehicleDto>> SearchAsync(SearchVehiclesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết phương tiện.", "")]
    public Task<Result<VehicleDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetVehicleRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới phương tiện.", "")]
    public Task<Result<Guid>> CreateAsync(CreateVehicleRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật phương tiện.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateVehicleRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa phương tiện.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteVehicleRequest(id));
    }

}