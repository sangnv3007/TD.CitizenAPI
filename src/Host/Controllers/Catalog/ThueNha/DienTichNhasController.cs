using TD.CitizenAPI.Application.Catalog.DienTichNhas;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class DienTichNhasController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục thị trường hàng hóa.", "")]
    public Task<PaginationResponse<DienTichNhaDto>> SearchAsync(SearchDienTichNhasRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết danh mục thị trường hàng hóa.", "")]
    public Task<Result<DienTichNhaDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetDienTichNhaRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới danh mục thị trường hàng hóa.", "")]
    public Task<Result<Guid>> CreateAsync(CreateDienTichNhaRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật danh mục thị trường hàng hóa.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateDienTichNhaRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa danh mục thị trường hàng hóa.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteDienTichNhaRequest(id));
    }
}