using EventBus.Abstractions;
using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.IntegrationEvents
{
    public class ProductIntegrationEventService : IProductIntegrationEventService
    {
        private readonly IEventBus _eventBus;
     
        public ProductIntegrationEventService(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task AddAndSaveEventAsync(IntegrationEvent evt)
        {
            throw new NotImplementedException();
        }

        public async Task PublishEventsThroughEventBusAsync(IntegrationEvent @event) 
        {
            try
            {
               _eventBus.Publish(@event);
            }
            catch (Exception ex) { }
        }

    }
}
