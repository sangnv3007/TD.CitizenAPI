using TD.CitizenAPI.Application.Catalog.JobAges;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class JobAgesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách độ tuổi.", "")]
    public Task<PaginationResponse<JobAgeDto>> SearchAsync(SearchJobAgesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết độ tuổi.", "")]
    public Task<Result<JobAgeDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetJobAgeRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới độ tuổi.", "")]
    public Task<Result<Guid>> CreateAsync(CreateJobAgeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật độ tuổi.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateJobAgeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa độ tuổi.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteJobAgeRequest(id));
    }

   
}