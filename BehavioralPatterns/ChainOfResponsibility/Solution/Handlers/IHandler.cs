using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Solution.Handlers
{
    public interface IHandler<TRequest, TResponse>
    {
        IHandler<TRequest, TResponse> SetNext(IHandler<TRequest, TResponse> handler);
        TResponse Handle(TRequest request);
    }
}
