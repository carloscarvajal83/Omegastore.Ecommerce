using Dapper;
using Omegastore.Ecommerce.Domain.Entity;
using Omegastore.Ecommerce.Infrastructure.Data;
using Omegastore.Ecommerce.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Omegastore.Ecommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public User Authenticate(string username, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);
                var user = connection.QuerySingle<User>(query, param: parameters, commandType:CommandType.StoredProcedure);
                return user;
            };
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Customer Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
