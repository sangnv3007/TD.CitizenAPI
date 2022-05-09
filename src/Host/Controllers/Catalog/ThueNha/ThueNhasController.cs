using TD.CitizenAPI.Application.Catalog.ThueNhas;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class ThueNhasController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh mục hàng hóa.", "")]
    public Task<PaginationResponse<ThueNhaDto>> SearchAsync(SearchThueNhasRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết hàng hóa.", "")]
    public Task<Result<ThueNhaDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetThueNhaRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới hàng hóa.", "")]
    public Task<Result<Guid>> CreateAsync(CreateThueNhaRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateThueNhaRequest request, Guid id)
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
        return Mediator.Send(new DeleteThueNhaRequest(id));
    }


}