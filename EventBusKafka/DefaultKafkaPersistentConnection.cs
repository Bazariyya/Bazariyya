using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusKafka
{
    public class DefaultKafkaPersistentConnection : IKafkaPersistentConnection
    {
        public bool IsConnected => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool TryConnect()
        {
            throw new NotImplementedException();
        }
    }
}
