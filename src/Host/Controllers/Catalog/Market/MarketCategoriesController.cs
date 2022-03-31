using TD.CitizenAPI.Application.Catalog.MarketCategories;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class MarketCategoriesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục thị trường hàng hóa.", "")]
    public Task<PaginationResponse<MarketCategoryDto>> SearchAsync(SearchMarketCategoriesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết danh mục thị trường hàng hóa.", "")]
    public Task<Result<MarketCategoryDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetMarketCategoryRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới danh mục thị trường hàng hóa.", "")]
    public Task<Result<Guid>> CreateAsync(CreateMarketCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật danh mục thị trường hàng hóa.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateMarketCategoryRequest request, Guid id)
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
        return Mediator.Send(new DeleteMarketCategoryRequest(id));
    }
}