using System;

namespace Actio.Common.Events.Interfaces
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid UserId { get; }
    }
}