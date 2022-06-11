using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Logging
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
