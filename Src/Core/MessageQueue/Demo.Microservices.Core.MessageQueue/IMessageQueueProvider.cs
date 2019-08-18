using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Demo.Microservices.Core.MessageQueue
{
   public interface IMessageQueueProvider
   {
       void Push(object message);
       T GetMessage<T>();
   }
}
