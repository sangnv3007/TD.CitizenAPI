using TD.CitizenAPI.Application.Catalog.Categories;
using TD.CitizenAPI.Application.Catalog.PlaceTypes;
using TD.CitizenAPI.Application.Catalog.VehicleTypes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class VehicleTypesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách loại phương tiện.", "")]
    public Task<PaginationResponse<VehicleTypeDto>> SearchAsync(SearchVehicleTypesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết loại phương tiện.", "")]
    public Task<Result<VehicleTypeDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetVehicleTypeRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới loại phương tiện.", "")]
    public Task<Result<Guid>> CreateAsync(CreateVehicleTypeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật loại phương tiện.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateVehicleTypeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa loại phương tiện.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteVehicleTypeRequest(id));
    }

}