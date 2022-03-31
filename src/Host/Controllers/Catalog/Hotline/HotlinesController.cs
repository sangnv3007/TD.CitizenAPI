using TD.CitizenAPI.Application.Catalog.Categories;
using TD.CitizenAPI.Application.Catalog.Hotlines;
using TD.CitizenAPI.Application.Catalog.PlaceTypes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class HotlinesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách tổng đài thông minh.", "")]
    public Task<PaginationResponse<HotlineDto>> SearchAsync(SearchHotlinesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết tổng đài thông minh.", "")]
    public Task<Result<HotlineDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetHotlineRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới tổng đài thông minh.", "")]
    public Task<Result<Guid>> CreateAsync(CreateHotlineRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật tổng đài thông minh.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateHotlineRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa tổng đài thông minh.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteHotlineRequest(id));
    }

}