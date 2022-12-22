using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Omegastore.Ecommerce.Domain.Entity;

namespace Omegastore.Ecommerce.Infrastructure.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
