using TD.CitizenAPI.Application.Catalog.JobSaveds;
using TD.CitizenAPI.Application.Catalog.JobTypes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class JobSavedsController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Search categories using available filters.", "")]
    public Task<PaginationResponse<JobSavedDto>> SearchAsync(SearchJobSavedsRequest request)
    {
        return Mediator.Send(request);
    }



    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Result<Guid>> CreateAsync(CreateJobSavedRequest request)
    {
        return Mediator.Send(request);
    }



    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Delete a category.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteJobSavedRequest(id));
    }

   
}