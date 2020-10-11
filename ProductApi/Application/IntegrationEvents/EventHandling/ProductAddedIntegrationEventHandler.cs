using EventBus.Abstractions;
using Product.API.Application.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.IntegrationEvents.EventHandling
{
    public class ProductAddedIntegrationEventHandler : IIntegrationEventHandler<ProductAddedIntegrationEvent>
    {
        public Task Handle(ProductAddedIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
