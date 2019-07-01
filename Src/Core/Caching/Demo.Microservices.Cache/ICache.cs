using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Microservices.Core.Cache
{
    public interface ICache
    {
        void Remove(string key);
        void Store(string key, object data);
        T Retrieve<T>(string storageKey);
    }
}
