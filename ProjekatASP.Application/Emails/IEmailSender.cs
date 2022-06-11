using ProjekatASP.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Emails
{
    public interface IEmailSender
    {
        void Send(MessageDto message);
    }
}
