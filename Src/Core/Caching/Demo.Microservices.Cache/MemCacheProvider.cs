using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Microservices.Core.Cache
{
  public  class MemCacheProvider:ICache
    {
        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object data)
        {
            throw new NotImplementedException();
        }

        public T Retrieve<T>(string storageKey)
        {
            throw new NotImplementedException();
        }
    }
}
