using TD.CitizenAPI.Application.Catalog.Places;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class PlacesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách địa điểm.", "")]
    public Task<PaginationResponse<PlaceDto>> SearchAsync(SearchPlacesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết  địa điểm.", "")]
    public Task<Result<PlaceDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetPlaceRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới địa điểm.", "")]
    public Task<Result<Guid>> CreateAsync(CreatePlaceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhât  địa điểm.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdatePlaceRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa  địa điểm.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeletePlaceRequest(id));
    }

   
}