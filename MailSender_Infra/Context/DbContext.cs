using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender_Infra.Context
{
    public sealed class DbContext : IDisposable
    {
        private readonly IConfiguration _configuration;
        public IDbConnection Connection { get; set; }
        public IDbTransaction? Transaction { get; set; }

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = new SqlConnection(_configuration.GetConnectionString("SqlServer"));
            Connection.Open();
        }
        public void Dispose() => Connection.Dispose();
    }
}
