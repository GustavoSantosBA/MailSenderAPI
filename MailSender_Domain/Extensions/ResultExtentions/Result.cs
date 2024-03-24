using MailSender_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Extensions.ResultExtentions
{
    public abstract class Result<T>
    {
        public abstract bool IsSuccess { get; }
        public abstract EResultType ResultType { get; }
        public abstract HttpStatusCode StatusCode { get; }
        public abstract List<string> Errors { get; }
        public abstract IEnumerable<T> Data { get; }
    }
}
