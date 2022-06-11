using ProjekatASP.Application.Emails;
using ProjekatASP.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatASP.Api.Emails
{
    public class EmailSender : IEmailSender
    {
        public void Send(MessageDto message)
        {
            System.Console.WriteLine("Sending email:");
            System.Console.WriteLine("To: " + message.To);
            System.Console.WriteLine("Title: " + message.Title);
            System.Console.WriteLine("Body: " + message.Body);
        }
    }
}
