using Confluent.Kafka;
using ProductApi.Messaging.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Implemention.Kafka.Producer
{
    public class ProductProducer : IProductProducer
    {
        private static ProductProducer _instance;
        public static ProductProducer instance => _instance ?? (_instance = new ProductProducer());

        private IProducer<Null, string> producer;

        private ProductProducer()
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async void SendMessage(string message)
        {
            try
            {
                var dr = await producer.ProduceAsync("User", new Message<Null, string> { Value = message });
                Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}
