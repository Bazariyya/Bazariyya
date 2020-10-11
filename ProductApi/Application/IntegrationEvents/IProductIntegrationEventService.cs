using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.IntegrationEvents
{
    public interface IProductIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(IntegrationEvent @event);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
