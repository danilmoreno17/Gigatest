using Kameyo.Core.Domain.Common;

namespace Kameyo.Core.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
