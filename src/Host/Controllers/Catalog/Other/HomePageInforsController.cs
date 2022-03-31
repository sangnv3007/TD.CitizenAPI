using TD.CitizenAPI.Application.Catalog.Categories;
using TD.CitizenAPI.Application.Catalog.HomePageInfors;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class HomePageInforsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách ảnh chủ đề trên mobile.", "")]
    public Task<PaginationResponse<HomePageInforDto>> SearchAsync(SearchHomePageInforsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết ảnh chủ đề trên mobile.", "")]
    public Task<Result<HomePageInforDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetHomePageInforRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới ảnh chủ đề trên mobile.", "")]
    public Task<Result<Guid>> CreateAsync(CreateHomePageInforRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật ảnh chủ đề trên mobile.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateHomePageInforRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa ảnh chủ đề trên mobile.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteHomePageInforRequest(id));
    }
}