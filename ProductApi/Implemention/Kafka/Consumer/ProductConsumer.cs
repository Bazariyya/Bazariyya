﻿using Confluent.Kafka;
using ProductApi.Messaging.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApi.Implemention.Kafka.Consumer
{
    public class ProductConsumer: IProductConsumer
    {
        private static ProductConsumer _instance;
        public static ProductConsumer instance => _instance ?? (_instance = new ProductConsumer());

        private IConsumer<Ignore, string> consumer;

        private ProductConsumer()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "localhost:9092",
                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<Ignore, string>(conf).Build();
            Task.Run(() => {
                ReadMessageStart();
            });
        }

        private void ReadMessageStart()
        {
            consumer.Subscribe("User");

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };
            
            try
            {
                while (true)
                {
                    try
                    {
                        var cr = consumer.Consume(cts.Token);
                        Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                consumer.Close();
            }
        }
    }
}

