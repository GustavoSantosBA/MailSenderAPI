using MailSender_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Extensions.ResultExtentions
{
    public class NotFoundResult<T> : Result<T>
    {
        private readonly string _error;
        public NotFoundResult(string error)
        {
            _error = error;
        }

        public override bool IsSuccess => false;
        public override EResultType ResultType => EResultType.NotFound;
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        public override List<string> Errors => new() { _error ?? "objeto não encontrado" };
        public override IEnumerable<T> Data => default;
    }
}
