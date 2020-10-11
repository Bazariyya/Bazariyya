using Autofac;
using Confluent.Kafka;
using EventBus;
using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusKafka
{
    public class EventBusKafka : IEventBus, IDisposable
    {
        const string BROKER_NAME = "Bazariyya";
        private readonly IKafkaPersistentConnection _persistentConnection;
        private readonly IEventBusSubscriptionsManager _subsManager;
        private readonly ILifetimeScope _autofac;
        ILogger _logger;
        private readonly string AUTOFAC_SCOPE_NAME = "eshop_event_bus";
        private readonly int _retryCount;

        private string _queueName;
        public EventBusKafka(IEventBusSubscriptionsManager subsManager, ILogger logger,
            string queueName = null, int retryCount = 5)
        {
            _subsManager = subsManager ?? new InMemoryEventBusSubscriptionsManager();
            _queueName = queueName;
            _logger = logger;
            //_consumerChannel = CreateConsumerChannel();
            _retryCount = retryCount;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Publish(IntegrationEvent @event) 
        {
            try
            {
                Console.WriteLine($"Delivered");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void SubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler
        {
            throw new NotImplementedException();
        }
    }
}
