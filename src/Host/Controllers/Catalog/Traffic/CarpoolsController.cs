using TD.CitizenAPI.Application.Catalog.Carpools;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class CarpoolsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách đi chung xe.", "")]
    public Task<PaginationResponse<CarpoolDto>> SearchAsync(SearchCarpoolsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết đi chung xe.", "")]
    public Task<Result<CarpoolDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCarpoolRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới đi chung xe.", "")]
    public Task<Result<Guid>> CreateAsync(CreateCarpoolRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật đi chung xe.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCarpoolRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa đi chung xe.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCarpoolRequest(id));
    }

   
}