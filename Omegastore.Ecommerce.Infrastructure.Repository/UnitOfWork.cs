using Omegastore.Ecommerce.Infrastructure.Interfaces;

namespace Omegastore.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customer { get; }

        public IUserRepository User { get; }

        public UnitOfWork(ICustomerRepository customer, IUserRepository user)
        {
            Customer = customer;
            User = user;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
