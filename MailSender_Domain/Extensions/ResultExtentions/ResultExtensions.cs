using MailSender_Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Domain.Extensions.ResultExtentions
{
    public static class ResultExtensions
    {
        public static ActionResult FromResult<T>(this ControllerBase controller, Result<T> result)
        {
            switch (result.ResultType)
            {
                case EResultType.Ok:
                    if (!result.Data.Any())
                        return controller.NoContent();
                    return controller.Ok(result); //result.Data
                case EResultType.NotFound:
                    return controller.NotFound(result); //result.Errors
                case EResultType.Invalid:
                    return controller.BadRequest(result); //result.Errors
                case EResultType.Unexpected:
                    return controller.BadRequest(result); //result.Errors
                case EResultType.Unauthorized:
                    return controller.Unauthorized();
                default:
                    throw new Exception("An unhandled result has occurred as a result of a service call.");
            }
        }
    }
}
