using MailSender_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Extensions.ResultExtentions
{
    public class UnexpectedResult<T> : Result<T>
    {
        private readonly string _error;

        public UnexpectedResult(string error)
        {
            _error = error;
        }

        public override bool IsSuccess => false;
        public override EResultType ResultType => EResultType.Unexpected;
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
        public override List<string> Errors => new() { _error ?? "Ocorreu um erro inesperado" };
        public override IEnumerable<T>? Data => default;
    }
}
