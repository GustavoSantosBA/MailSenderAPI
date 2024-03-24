using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Enums
{
    public enum EResultType
    {
        Ok = 1,
        Unexpected = 2,
        NotFound = 3,
        Unauthorized = 4,
        Invalid = 5
    }
}
