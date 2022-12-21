using Omegastore.Ecommerce.Domain.Entity;

namespace Omegastore.Ecommerce.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
    }
}
