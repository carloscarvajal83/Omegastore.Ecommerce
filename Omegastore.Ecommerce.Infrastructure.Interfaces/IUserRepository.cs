using Omegastore.Ecommerce.Domain.Entity;

namespace Omegastore.Ecommerce.Infrastructure.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
