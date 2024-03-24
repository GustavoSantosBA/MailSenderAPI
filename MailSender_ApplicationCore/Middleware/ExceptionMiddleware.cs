using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using MailSender_ApplicationCore.Models;
using MailSender_ApplicationCore.Exceptions;

namespace MailSender_ApplicationCore.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var errorId = Guid.NewGuid().ToString();
                LogContext.PushProperty("ErrorId", errorId);
                LogContext.PushProperty("StackTrace", exception.StackTrace);
                var errorResult = new ErrorResult
                {
                    Source = exception.TargetSite?.DeclaringType?.FullName,
                    Exception = exception.Message.Trim(),
                    ErrorId = errorId,
                    SupportMessage =
                        $"Enviar esse ID: {errorId} para o suporte fazer analise caso possua ferramenta de analise."
                };
                errorResult.Messages.Add(exception.Message);

                if (exception is not CustomException && exception.InnerException != null)
                {
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                    }
                }

                switch (exception)
                {
                    case CustomException e:
                        errorResult.StatusCode = (int)e.StatusCode;
                        if (e.ErrorMessages is not null)
                        {
                            errorResult.Messages = e.ErrorMessages;
                        }

                        break;

                    case KeyNotFoundException:
                        errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                Log.Error($"{errorResult.Exception} Request failed with Status Code {context.Response.StatusCode} and Error Id {errorId}.");
                var response = context.Response;
                if (!response.HasStarted)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = errorResult.StatusCode;

                    var result = JsonSerializer.Serialize(errorResult);
                    await response.WriteAsync(result);
                }
                else
                {
                    Log.Warning("Nao foi possivel escrever a resposta do erro. Reposta ja iniciada.");
                }
            }
        }
    }
}
