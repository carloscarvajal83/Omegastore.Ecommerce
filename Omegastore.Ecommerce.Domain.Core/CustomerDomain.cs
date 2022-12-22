using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Omegastore.Ecommerce.Domain.Entity;
using Omegastore.Ecommerce.Domain.Interfaces;
using Omegastore.Ecommerce.Infrastructure.Interfaces;

namespace Omegastore.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CustomerDomain(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public bool Insert(Customer customer)
        {
            return _unitOfWork.Customer.Insert(customer);
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            return await _unitOfWork.Customer.InsertAsync(customer);
        }

        public bool Update(Customer customer)
        {
            return _unitOfWork.Customer.Update(customer);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            return await _unitOfWork.Customer.UpdateAsync(customer);
        }

        public bool Delete(string customerId)
        {
            return _unitOfWork.Customer.Delete(customerId);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.Customer.DeleteAsync(customerId);
        }

        public Customer Get(string customerId)
        {
            return _unitOfWork.Customer.Get(customerId);
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            return await _unitOfWork.Customer.GetAsync(customerId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _unitOfWork.Customer.GetAll();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _unitOfWork.Customer.GetAllAsync();
        }
    }
}
