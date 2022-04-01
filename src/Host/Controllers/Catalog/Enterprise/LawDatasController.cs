using TD.CitizenAPI.Application.Catalog.AlertCategories;
using TD.CitizenAPI.Application.Catalog.LawDatas;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class LawDatasController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục thông tin cảnh báo.", "")]
    public Task<PaginationResponse<LawDataDto>> SearchAsync(SearchLawDatasRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết danh mục thông tin cảnh báo.", "")]
    public Task<Result<LawDataDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetLawDataRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới danh mục thông tin cảnh báo.", "")]
    public Task<Result<Guid>> CreateAsync(CreateLawDataRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật danh mục thông tin cảnh báo.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateLawDataRequest request, Guid id)
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
        return Mediator.Send(new DeleteLawDataRequest(id));
    }
}