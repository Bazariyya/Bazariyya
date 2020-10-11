using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.IntegrationEvents.Events
{
    public class ProductAddedIntegrationEvent : IntegrationEvent
    {
        public int? productId { get; set; }
    }
}
