using TD.CitizenAPI.Application.Catalog.JobApplications;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class JobApplicationsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách CV của người dùng.", "")]
    public Task<PaginationResponse<JobApplicationDto>> SearchAsync(SearchJobApplicationsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết CV.", "")]
    public Task<Result<JobApplicationDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetJobApplicationRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới CV.", "")]
    public Task<Result<Guid>> CreateAsync(CreateJobApplicationRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật CV.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateJobApplicationRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa CV.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteJobApplicationRequest(id));
    }

   
}