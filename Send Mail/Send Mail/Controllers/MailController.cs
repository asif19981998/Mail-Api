using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Send_Mail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        public string Index()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Project", "rakibulasif1998@gmail.com"));
            message.To.Add(new MailboxAddress("Test Project", "asifhuda19981998@gmail.com"));
            message.Subject = "Test Message";
            message.Body = new TextPart("plain")
            {
                Text = "Hello Huda"
            };
            using(var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("rakibulasif1998@gmail.com", "123258asif");
                client.Send(message);
                client.Disconnect(true);
            }

            return "success";
        }
    }
}
