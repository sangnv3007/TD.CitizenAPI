using TD.CitizenAPI.Application.Catalog.Experiences;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class ExperiencesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách loại kinh nghiệm.", "")]
    public Task<PaginationResponse<ExperienceDto>> SearchAsync(SearchExperiencesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết loại kinh nghiệm.", "")]
    public Task<Result<ExperienceDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetExperienceRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới loại kinh nghiệm.", "")]
    public Task<Result<Guid>> CreateAsync(CreateExperienceRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật loại kinh nghiệm.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateExperienceRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa loại kinh nghiệm.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteExperienceRequest(id));
    }

   
}