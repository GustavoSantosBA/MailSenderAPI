using MailSender_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Extensions.ResultExtentions
{
    public class InvalidResult<T> : Result<T>
    {
        private readonly List<string> _errors;
        public InvalidResult(string error)
        {
            _errors = new() { error ?? "ocorreu um erro" }; ;
        }

        public InvalidResult(List<string> errors)
        {
            _errors = errors;
        }

        public override bool IsSuccess => false;
        public override EResultType ResultType => EResultType.Invalid;
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public override List<string> Errors => _errors;
        public override IEnumerable<T> Data => default;
    }
}
