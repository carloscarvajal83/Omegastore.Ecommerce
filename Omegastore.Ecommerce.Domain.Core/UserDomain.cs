using Omegastore.Ecommerce.Domain.Entity;
using Omegastore.Ecommerce.Domain.Interfaces;
using Omegastore.Ecommerce.Infrastructure.Interfaces;

namespace Omegastore.Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
            return _unitOfWork.User.Authenticate(username, password);
        }
    }
}
