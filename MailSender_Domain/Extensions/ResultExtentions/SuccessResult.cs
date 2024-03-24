using MailSender_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Extensions.ResultExtentions
{
    public class SuccessResult<T> : Result<T>
    {
        private readonly IEnumerable<T> _data;
        public SuccessResult(IEnumerable<T> data)
        {
            _data = data;
        }

        public override bool IsSuccess => true;
        public override EResultType ResultType => EResultType.Ok;
        public override HttpStatusCode StatusCode => HttpStatusCode.OK;
        public override List<string> Errors => new();
        public override IEnumerable<T> Data => _data;

        public int TotalRecords { get; set; }
    }
}
