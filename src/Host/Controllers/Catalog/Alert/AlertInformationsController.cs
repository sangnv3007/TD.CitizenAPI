using TD.CitizenAPI.Application.Catalog.AlertInformations;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class AlertInformationsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách thông tin cảnh báo.", "")]
    public Task<PaginationResponse<AlertInformationDto>> SearchAsync(SearchAlertInformationsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết  thông tin cảnh báo.", "")]
    public Task<Result<AlertInformationDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAlertInformationRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới  thông tin cảnh báo.", "")]
    public Task<Result<Guid>> CreateAsync(CreateAlertInformationRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật thông tin cảnh báo.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAlertInformationRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa thông tin cảnh báo.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteAlertInformationRequest(id));
    }
}