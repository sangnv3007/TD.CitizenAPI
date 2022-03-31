using TD.CitizenAPI.Application.Catalog.JobPositions;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class JobPositionsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách vị trí làm việc.", "")]
    public Task<PaginationResponse<JobPositionDto>> SearchAsync(SearchJobPositionsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết vị trí làm việc.", "")]
    public Task<Result<JobPositionDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetJobPositionRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới vị trí làm việc.", "")]
    public Task<Result<Guid>> CreateAsync(CreateJobPositionRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật vị trí làm việc.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateJobPositionRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa vị trí làm việc.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteJobPositionRequest(id));
    }

   
}