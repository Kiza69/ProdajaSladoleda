using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.Application.Interface
{
    public interface IEmailSending
    {
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        void Send();
    }
}
