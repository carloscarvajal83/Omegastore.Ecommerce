using System;

namespace Omegastore.Ecommerce.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }

        IUserRepository User { get; }
    }
}
