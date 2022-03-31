using TD.CitizenAPI.Application.Catalog.JobSaveds;
using TD.CitizenAPI.Application.Catalog.JobTypes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class JobSavedsController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách công việc đã lưu.", "")]
    public Task<PaginationResponse<JobSavedDto>> SearchAsync(SearchJobSavedsRequest request)
    {
        return Mediator.Send(request);
    }



    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Lưu công việc mới.", "")]
    public Task<Result<Guid>> CreateAsync(CreateJobSavedRequest request)
    {
        return Mediator.Send(request);
    }



    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa công việc đã lưu.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteJobSavedRequest(id));
    }

   
}