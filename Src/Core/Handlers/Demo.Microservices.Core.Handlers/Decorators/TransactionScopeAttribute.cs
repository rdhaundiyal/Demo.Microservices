using System;

namespace Demo.Microservices.Core.Handlers.Decorators

{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class TransactionScopeAttribute : Attribute
    {
        
    }
}
