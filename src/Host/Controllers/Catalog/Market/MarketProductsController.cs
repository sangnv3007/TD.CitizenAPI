using TD.CitizenAPI.Application.Catalog.MarketProducts;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class MarketProductsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh mục hàng hóa.", "")]
    public Task<PaginationResponse<MarketProductDto>> SearchAsync(SearchMarketProductsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết hàng hóa.", "")]
    public Task<Result<MarketProductDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetMarketProductRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới hàng hóa.", "")]
    public Task<Result<Guid>> CreateAsync(CreateMarketProductRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateMarketProductRequest request, Guid id)
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
        return Mediator.Send(new DeleteMarketProductRequest(id));
    }

    [HttpPost("fetchdata")]
    //[MustHavePermission(FSHAction.Generate, FSHResource.Brands)]
    [OpenApiOperation("Fetch dữ liệu hàng hóa.", "")]
    public Task<string> FetchMarketProductAsync(FetchMarketProductRequest request)
    {
        return Mediator.Send(request);
    }
}