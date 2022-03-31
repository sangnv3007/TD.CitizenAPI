using TD.CitizenAPI.Application.Catalog.Categories;
using TD.CitizenAPI.Application.Catalog.Notifications;
using TD.CitizenAPI.Application.Catalog.PlaceTypes;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class NotificationsController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách thông báo.", "")]
    public Task<PaginationResponse<NotificationDto>> SearchAsync(SearchNotificationsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết thông báo.", "")]
    public Task<Result<NotificationDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetNotificationRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới thông báo.", "")]
    public Task<Result<Guid>> CreateAsync(CreateNotificationRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật thông báo.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateNotificationRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa thông báo.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteNotificationRequest(id));
    }

    [HttpPost("send-notification")]
    //[MustHavePermission(FSHAction.Generate, FSHResource.Brands)]
    [OpenApiOperation("Gửi thông báo.", "")]
    public Task<string> GenerateRandomAsync(SendNotificationRequest request)
    {
        return Mediator.Send(request);
    }
}