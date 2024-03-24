using MailSender_ApplicationCore.Services;
using MailSender_Domain.Interfaces.Services;
using MailSender_Infra.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_InfraCrossCutting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();

            // Infra.DbContext
            services.AddScoped<DbContext>();

            // Core.Services
            services.AddScoped<IMailSenderService, MailSenderrService>();

            //Infra.Repository
        }
    }
}
