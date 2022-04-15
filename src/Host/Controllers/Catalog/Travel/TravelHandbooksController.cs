using TD.CitizenAPI.Application.Catalog.TravelHandbooks;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class TravelHandbooksController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách chính sách đi xe.", "")]
    public Task<PaginationResponse<TravelHandbookDto>> SearchAsync(SearchTravelHandbooksRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết chính sách đi xe.", "")]
    public Task<Result<TravelHandbookDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetTravelHandbookRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới chính sách đi xe.", "")]
    public Task<Result<Guid>> CreateAsync(CreateTravelHandbookRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật chính sách đi xe.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateTravelHandbookRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa chính sách đi xe.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteTravelHandbookRequest(id));
    }

}