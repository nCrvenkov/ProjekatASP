using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.UseCases
{
    public interface IQuery<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest search);
    }
}
