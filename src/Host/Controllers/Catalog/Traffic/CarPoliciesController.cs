using TD.CitizenAPI.Application.Catalog.CarPolicies;


namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class CarPoliciesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách chính sách đi xe.", "")]
    public Task<PaginationResponse<CarPolicyDto>> SearchAsync(SearchCarPoliciesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết chính sách đi xe.", "")]
    public Task<Result<CarPolicyDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCarPolicyRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới chính sách đi xe.", "")]
    public Task<Result<Guid>> CreateAsync(CreateCarPolicyRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật chính sách đi xe.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCarPolicyRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa chính sách đi xe.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCarPolicyRequest(id));
    }

}