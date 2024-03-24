using MailSender_Domain.Entities;
using MailSender_Domain.Extensions.ResultExtentions;
using MailSender_Domain.Interfaces.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MailSender_ApplicationCore.Services
{
    public class MailSenderrService : IMailSenderService
    {
        public async Task<Result<string>> SendMail(Parameters model)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                SmtpClient client = new SmtpClient();
                client.Host = model.Host;
                client.Port = model.Porta;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(model.Usuario, model.Senha);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mail = new MailMessage();
                mail.Sender = new MailAddress(model.Remetente, model.Assunto);
                mail.From = new MailAddress(model.Remetente, model.Assunto);

                if (!string.IsNullOrEmpty(model.Anexos))
                {
                    foreach (var item in model.Anexos.Split(';'))
                    {
                        mail.Attachments.Add(new Attachment(item));
                    }
                }

                foreach (var item in model.Destinatarios.Split(';'))
                {
                    mail.To.Add(new MailAddress(item));
                }

                mail.Subject = model.Assunto;
                mail.Body = model.Mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //
                client.Send(mail);

                return new SuccessResult<string>(new[] { "Email enviado com sucesso!" });
            }
            catch (Exception ex)
            {
                return new InvalidResult<string>($"Falha ao enviar e-mail {ex.Message} {ex.InnerException}");
            }
        }
    }
}
