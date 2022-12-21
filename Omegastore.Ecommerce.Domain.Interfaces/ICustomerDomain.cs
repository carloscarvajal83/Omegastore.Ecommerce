using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Omegastore.Ecommerce.Domain.Entity;

namespace Omegastore.Ecommerce.Domain.Interfaces
{
    public interface ICustomerDomain
    {
        #region Metodos sincronos
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(string customerId);
        Customer Get(string customerId);
        IEnumerable<Customer> GetAll();

        #endregion

        Task<bool> InsertAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customer> GetAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
