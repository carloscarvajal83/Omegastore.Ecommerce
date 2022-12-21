using Omegastore.Ecommerce.Domain.Entity;
using Omegastore.Ecommerce.Domain.Interfaces;
using Omegastore.Ecommerce.Infrastructure.Interfaces;

namespace Omegastore.Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;
        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }
    }
}
