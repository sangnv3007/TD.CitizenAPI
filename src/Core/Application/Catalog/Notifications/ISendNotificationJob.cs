using System.ComponentModel;

namespace TD.CitizenAPI.Application.Catalog.Notifications;

public interface ISendNotificationJob : IScopedService
{
    [DisplayName("Send Notification")]
    Task SendNotificationAsync(SendNotificationRequest request, CancellationToken cancellationToken);

}