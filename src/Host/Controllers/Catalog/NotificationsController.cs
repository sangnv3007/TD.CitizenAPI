using TD.CitizenAPI.Application.Catalog.Categories;
using TD.CitizenAPI.Application.Catalog.Notifications;
using TD.CitizenAPI.Application.Catalog.PlaceTypes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class NotificationsController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Search categories using available filters.", "")]
    public Task<PaginationResponse<NotificationDto>> SearchAsync(SearchNotificationsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Get category details.", "")]
    public Task<Result<NotificationDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetNotificationRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Result<Guid>> CreateAsync(CreateNotificationRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateNotificationRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Delete a category.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteNotificationRequest(id));
    }

    [HttpPost("send-notification")]
    //[MustHavePermission(FSHAction.Generate, FSHResource.Brands)]
    [OpenApiOperation("Generate a number of random brands.", "")]
    public Task<string> GenerateRandomAsync(SendNotificationRequest request)
    {
        return Mediator.Send(request);
    }
}