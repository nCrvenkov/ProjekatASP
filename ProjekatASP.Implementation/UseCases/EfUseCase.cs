using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(ProjekatDbContext context)
        {
            Context = context;
        }

        protected ProjekatDbContext Context { get; }
    }
}
