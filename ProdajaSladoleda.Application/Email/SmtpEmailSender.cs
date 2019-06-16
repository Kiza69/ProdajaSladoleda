using ProdajaSladoleda.Application.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ProdajaSladoleda.Application.Email
{
    public class SmtpEmailSender : IEmailSending
    {
        private string _host;
        private int _port;
        private string _fromAddress;
        private string _password;

        public SmtpEmailSender(string host, int port, string fromAddress, string password)
        {
            _host = host;
            _port = port;
            _fromAddress = fromAddress;
            _password = password;
        }

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void Send()
        {
            var smtp = new SmtpClient
            {
                Host = _host,
                Port = _port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromAddress, _password)
            };
            using (var message = new MailMessage(_fromAddress, To)
            {
                Subject = Subject,
                Body = Body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
