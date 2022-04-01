using TD.CitizenAPI.Application.Catalog.AlertCategories;
using TD.CitizenAPI.Application.Catalog.ProjectInvestCategories;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class ProjectInvestCategoriesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục thông tin cảnh báo.", "")]
    public Task<PaginationResponse<ProjectInvestCategoryDto>> SearchAsync(SearchProjectInvestCategoriesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết danh mục thông tin cảnh báo.", "")]
    public Task<Result<ProjectInvestCategoryDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetProjectInvestCategoryRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới danh mục thông tin cảnh báo.", "")]
    public Task<Result<Guid>> CreateAsync(CreateProjectInvestCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật danh mục thông tin cảnh báo.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateProjectInvestCategoryRequest request, Guid id)
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
        return Mediator.Send(new DeleteProjectInvestCategoryRequest(id));
    }
}