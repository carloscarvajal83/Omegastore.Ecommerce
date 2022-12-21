using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Omegastore.Ecommerce.Shared.Common;

namespace Omegastore.Ecommerce.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration) {
            _configuration = configuration;
        }

        public IDbConnection GetConnection 
        {
            get {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) {
                    return null;
                }
                sqlConnection.ConnectionString = _configuration.GetConnectionString("DBConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
