using TD.CitizenAPI.Application.Catalog.HotlineCategories;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class HotlineCategoriesController : VersionedApiController
{
    //[ApiVersion("2.0")]
    [HttpPost("search")]
    [AllowAnonymous]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục tổng đài thông minh.", "")]
    public Task<PaginationResponse<HotlineCategoryDto>> SearchAsync(SearchHotlineCategoriesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết danh mục tổng đài thông minh.", "")]
    public Task<Result<HotlineCategoryDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetHotlineCategoryRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới danh mục tổng đài thông minh.", "")]
    public Task<Result<Guid>> CreateAsync(CreateHotlineCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật danh mục tổng đài thông minh.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateHotlineCategoryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa danh mục tổng đài thông minh.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteHotlineCategoryRequest(id));
    }
}