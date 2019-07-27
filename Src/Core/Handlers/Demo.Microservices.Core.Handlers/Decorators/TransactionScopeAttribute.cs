using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Microservices.Core.Handlers.Decorators

{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class TransactionScopeAttribute : Attribute
    {
        
    }
}
