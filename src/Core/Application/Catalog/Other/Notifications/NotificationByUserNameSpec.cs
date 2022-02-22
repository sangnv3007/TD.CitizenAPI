namespace TD.CitizenAPI.Application.Catalog.Notifications;

public class NotificationByUserNameSpec : Specification<Notification>
{
    public NotificationByUserNameSpec(string userName, bool? isRead) =>
        Query.Where(p => p.UserName == userName).Where(p => p.IsRead == isRead, isRead.HasValue);
}
