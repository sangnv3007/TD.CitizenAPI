using System.ComponentModel;

namespace TD.CitizenAPI.Application.Catalog.Notifications;

public interface ISendNotificationJob : IScopedService
{
    [DisplayName("Send Notification")]
    Task SendNotificationAsync(NotificationRequest request, CancellationToken cancellationToken);

}