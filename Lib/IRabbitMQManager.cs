using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public interface IRabbitMQManager
    {
        void Publish<T>(T message, string queueName);

        void Consume<T>(string queueName, Action<T> action) where T : class;
    }
}
