using TD.CitizenAPI.Application.Catalog.JobApplieds;
using TD.CitizenAPI.Application.Catalog.Salaries;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class JobAppliedsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách công việc đã ứng tuyển.", "")]
    public Task<PaginationResponse<JobAppliedDto>> SearchAsync(SearchCurrentJobAppliedsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("candidates")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách công việc đã ứng tuyển.", "")]
    public Task<PaginationResponse<JobAppliedDto>> SearchCandidatesAsync(SearchCandidatesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết công việc đã ứng tuyển.", "")]
    public Task<Result<JobAppliedDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetJobAppliedRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới ứng tuyển.", "")]
    public Task<Result<Guid>> CreateAsync(CreateJobAppliedRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa ứng tuyển.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteJobAppliedRequest(id));
    }

   
}