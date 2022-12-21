using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Omegastore.Ecommerce.Application.Dto;
using Omegastore.Ecommerce.Shared.Common;

namespace Omegastore.Ecommerce.Application.Interfaces
{
    public interface ICustomerApplication
    {
        #region Metodos sincronos
        Response<bool> Insert(CustomerDto customer);
        Response<bool> Update(CustomerDto customer);
        Response<bool> Delete(string customerId);
        Response<CustomerDto> Get(string customerId);
        Response<IEnumerable<CustomerDto>> GetAll();

        #endregion

        Task<Response<bool>> InsertAsync(CustomerDto customer);
        Task<Response<bool>> UpdateAsync(CustomerDto customer);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDto>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
    }
}
