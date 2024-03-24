using MailSender_Domain.Entities;
using MailSender_Domain.Extensions.ResultExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Interfaces.Services
{
    public interface IMailSenderService
    {
        Task<Result<string>> SendMail(Parameters model);
    }
}
