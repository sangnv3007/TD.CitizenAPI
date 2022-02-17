using TD.CitizenAPI.Shared.Events;

namespace TD.CitizenAPI.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}