using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Microservices.Services.Common
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class RetryAttibute : Attribute
    {
        public RetryAttibute()
        {
        }
    }
}
