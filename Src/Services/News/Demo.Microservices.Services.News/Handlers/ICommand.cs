using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Demo.Microservices.Services.News.Handlers
{
    public interface ICommand
    {
        Result Execute();
    }
}
