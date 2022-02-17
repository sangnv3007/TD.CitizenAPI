using TD.CitizenAPI.Shared.Events;

namespace TD.CitizenAPI.Domain.Common.Contracts;

public abstract class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}