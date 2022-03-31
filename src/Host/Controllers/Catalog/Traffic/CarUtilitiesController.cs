using TD.CitizenAPI.Application.Catalog.CarUtilities;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class CarUtilitiesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách tiện ích của xe.", "")]
    public Task<PaginationResponse<CarUtilityDto>> SearchAsync(SearchCarUtilitiesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết tiện ích xe.", "")]
    public Task<Result<CarUtilityDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCarUtilityRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới tiện ích xe.", "")]
    public Task<Result<Guid>> CreateAsync(CreateCarUtilityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật tiện ích xe.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCarUtilityRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa tiện ích xe.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCarUtilityRequest(id));
    }

}