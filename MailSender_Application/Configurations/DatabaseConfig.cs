using MailSender_Infra.Context;

namespace MailSender_Application.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<DbContext>();
        }
    }
}
