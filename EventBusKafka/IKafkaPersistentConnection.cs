using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusKafka
{
    public interface IKafkaPersistentConnection : 
        IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();
    }
}
