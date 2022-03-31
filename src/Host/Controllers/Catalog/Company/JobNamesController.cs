using TD.CitizenAPI.Application.Catalog.JobNames;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class JobNamesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách nghề nghiệp.", "")]
    public Task<PaginationResponse<JobNameDto>> SearchAsync(SearchJobNamesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết nghề nghiệp.", "")]
    public Task<Result<JobNameDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetJobNameRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới nghề nghiệp.", "")]
    public Task<Result<Guid>> CreateAsync(CreateJobNameRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật nghề nghiệp.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateJobNameRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa nghề nghiệp.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteJobNameRequest(id));
    }

   
}