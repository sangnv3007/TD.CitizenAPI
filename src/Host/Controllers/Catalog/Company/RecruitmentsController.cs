using TD.CitizenAPI.Application.Catalog.Recruitments;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class RecruitmentsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách tin tuyển dụng.", "")]
    public Task<PaginationResponse<RecruitmentDto>> SearchAsync(SearchRecruitmentsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết tin tuyển dụng.", "")]
    public Task<Result<RecruitmentDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetRecruitmentRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới tin tuyển dụng.", "")]
    public Task<Result<Guid>> CreateAsync(CreateRecruitmentRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật tin tuyển dụng.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateRecruitmentRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa tin tuyển dụng.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteRecruitmentRequest(id));
    }

   
}