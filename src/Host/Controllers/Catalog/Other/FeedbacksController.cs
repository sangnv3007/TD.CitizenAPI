using TD.CitizenAPI.Application.Catalog.Feedbacks;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class FeedbacksController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách feedback của người dùng.", "")]
    public Task<PaginationResponse<FeedbackDto>> SearchAsync(SearchFeedbacksRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết feedback của người dùng.", "")]
    public Task<Result<FeedbackDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetFeedbackRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới feedback của người dùng.", "")]
    public Task<Result<Guid>> CreateAsync(CreateFeedbackRequest request)
    {
        return Mediator.Send(request);
    }

   
}