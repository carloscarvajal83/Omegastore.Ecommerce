using Dapper;
using Omegastore.Ecommerce.Domain.Entity;
using Omegastore.Ecommerce.Infrastructure.Interfaces;
using Omegastore.Ecommerce.Shared.Common;
using System.Data;

namespace Omegastore.Ecommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public User Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);
                var user = connection.QuerySingle<User>(query, param: parameters, commandType:CommandType.StoredProcedure);
                return user;
            };
        }
    }
}
