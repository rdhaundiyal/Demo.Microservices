using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Microservices.Services.News.Service
{
    public interface IService<T>
    {
        T Get();
        IList<T> GetAll();

    }
}
