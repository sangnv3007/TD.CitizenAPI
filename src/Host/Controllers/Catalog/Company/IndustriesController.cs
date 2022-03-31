using TD.CitizenAPI.Application.Catalog.Industries;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class IndustriesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách ngành nghề kinh doanh.", "")]
    public Task<PaginationResponse<IndustryDto>> SearchAsync(SearchIndustriesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết ngành nghề kinh doanh.", "")]
    public Task<Result<IndustryDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetIndustryRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới ngành nghề kinh doanh.", "")]
    public Task<Result<Guid>> CreateAsync(CreateIndustryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật ngành nghề kinh doanh.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateIndustryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa ngành nghề kinh doanh.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteIndustryRequest(id));
    }

   
}