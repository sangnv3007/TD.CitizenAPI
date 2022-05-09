using TD.CitizenAPI.Application.Catalog.LoaiNhas;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class LoaiNhasController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh mục hàng hóa.", "")]
    public Task<PaginationResponse<LoaiNhaDto>> SearchAsync(SearchLoaiNhasRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết hàng hóa.", "")]
    public Task<Result<LoaiNhaDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetLoaiNhaRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới hàng hóa.", "")]
    public Task<Result<Guid>> CreateAsync(CreateLoaiNhaRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateLoaiNhaRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa hàng hóa.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteLoaiNhaRequest(id));
    }

}