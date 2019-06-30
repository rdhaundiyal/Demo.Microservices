using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Microservices.Core.Messages
{
   public class ResponseMessage<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }

        protected internal ResponseMessage(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }

    public sealed class ResponseMessage : ResponseMessage<string>
    {
        private ResponseMessage(string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static ResponseMessage<T> Ok<T>(T result)
        {
            return new ResponseMessage<T>(result, null);
        }

        public static ResponseMessage Ok()
        {
            return new ResponseMessage(null);
        }

        public static ResponseMessage Error(string errorMessage)
        {
            return new ResponseMessage(errorMessage);
        }
    }
}
