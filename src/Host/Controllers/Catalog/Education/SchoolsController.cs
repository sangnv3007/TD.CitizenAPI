using TD.CitizenAPI.Application.Catalog.AlertCategories;
using TD.CitizenAPI.Application.Catalog.Schools;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class SchoolsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục thông tin cảnh báo.", "")]
    public Task<PaginationResponse<SchoolDto>> SearchAsync(SearchSchoolsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết danh mục thông tin cảnh báo.", "")]
    public Task<Result<SchoolDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSchoolRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới danh mục thông tin cảnh báo.", "")]
    public Task<Result<Guid>> CreateAsync(CreateSchoolRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật danh mục thông tin cảnh báo.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSchoolRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa danh mục thông tin cảnh báo.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSchoolRequest(id));
    }
}