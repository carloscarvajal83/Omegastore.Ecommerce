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
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerDomain(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        public bool Insert(Customer customer)
        {
            return _customerRepository.Insert(customer);
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            return await _customerRepository.InsertAsync(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }

        public bool Delete(string customerId)
        {
            return _customerRepository.Delete(customerId);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _customerRepository.DeleteAsync(customerId);
        }

        public Customer Get(string customerId)
        {
            return _customerRepository.Get(customerId);
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            return await _customerRepository.GetAsync(customerId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }
    }
}
