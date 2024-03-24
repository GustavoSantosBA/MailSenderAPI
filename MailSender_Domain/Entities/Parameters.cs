using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MailSender_Domain.Entities
{
    public class Parameters 
    {
        public string Host { get; set; }
        public int Porta { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Remetente { get; set; }
        public string Destinatarios { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Anexos { get; set; }
    }
}
