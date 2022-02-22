using TD.CitizenAPI.Application.Catalog.Feedbacks;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class FeedbacksController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Search categories using available filters.", "")]
    public Task<PaginationResponse<FeedbackDto>> SearchAsync(SearchFeedbacksRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Get category details.", "")]
    public Task<Result<FeedbackDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetFeedbackRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Result<Guid>> CreateAsync(CreateFeedbackRequest request)
    {
        return Mediator.Send(request);
    }

   
}