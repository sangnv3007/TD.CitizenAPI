using TD.CitizenAPI.Application.Catalog.AlertOrganizations;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class AlertOrganizationsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách đơn vị cảnh báo.", "")]
    public Task<PaginationResponse<AlertOrganizationDto>> SearchAsync(SearchAlertOrganizationsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết đơn vị cảnh báo.", "")]
    public Task<Result<AlertOrganizationDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAlertOrganizationRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới đơn vị cảnh báo.", "")]
    public Task<Result<Guid>> CreateAsync(CreateAlertOrganizationRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật đơn vị cảnh báo.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAlertOrganizationRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa đơn vị cảnh báo.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteAlertOrganizationRequest(id));
    }
}