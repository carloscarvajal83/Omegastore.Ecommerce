using System.Threading.Tasks;
using System.Collections.Generic;
using Omegastore.Ecommerce.Domain.Entity;

namespace Omegastore.Ecommerce.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        #region Metodos sincronos
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(string id);
        Customer Get(string id);
        IEnumerable<T> GetAll();
        #endregion

        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
        Task<Customer> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
