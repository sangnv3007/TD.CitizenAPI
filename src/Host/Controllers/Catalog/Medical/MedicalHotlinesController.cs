using TD.CitizenAPI.Application.Catalog.MedicalHotlines;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class MedicalHotlinesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách tổng đài thông minh.", "")]
    public Task<PaginationResponse<MedicalHotlineDto>> SearchAsync(SearchMedicalHotlinesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết tổng đài thông minh.", "")]
    public Task<Result<MedicalHotlineDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetMedicalHotlineRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới tổng đài thông minh.", "")]
    public Task<Result<Guid>> CreateAsync(CreateMedicalHotlineRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật tổng đài thông minh.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateMedicalHotlineRequest request, Guid id)
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
        return Mediator.Send(new DeleteMedicalHotlineRequest(id));
    }

}