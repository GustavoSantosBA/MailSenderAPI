using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Entities
{
    public class BaseEntity
    {
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedDate { get; set; }
    }
}
