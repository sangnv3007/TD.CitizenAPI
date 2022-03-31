using TD.CitizenAPI.Application.Catalog.Degrees;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class DegreesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách loại bằng cấp.", "")]
    public Task<PaginationResponse<DegreeDto>> SearchAsync(SearchDegreesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết loại bằng cấp.", "")]
    public Task<Result<DegreeDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetDegreeRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới loại bằng cấp.", "")]
    public Task<Result<Guid>> CreateAsync(CreateDegreeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật loại bằng cấp.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateDegreeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa loại bằng cấp.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteDegreeRequest(id));
    }

   
}