using Omegastore.Ecommerce.Domain.Entity;

namespace Omegastore.Ecommerce.Domain.Interfaces
{
    public interface IUserDomain
    {
        User Authenticate(string username, string password);
    }
}
