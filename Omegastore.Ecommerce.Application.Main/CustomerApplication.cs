using System;
using AutoMapper;
using Omegastore.Ecommerce.Application.Dto;
using Omegastore.Ecommerce.Application.Interfaces;
using Omegastore.Ecommerce.Domain.Entity;
using Omegastore.Ecommerce.Domain.Interfaces;
using Omegastore.Ecommerce.Shared.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Omegastore.Ecommerce.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IMapper _mapper;
        private readonly ICustomerDomain _customerDomain;
        private readonly IAppLogger<CustomerApplication> _appLogger;

        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper, IAppLogger<CustomerApplication> appLogger)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
            _appLogger = appLogger;
        }

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Delete(customerId);
                response.Success = response.Data;
                response.Message = response.Data ? "Registro Exitoso" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);
                response.Success = response.Data;
                response.Message = response.Data ? "Registro Exitoso" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<CustomerDto> Get(string customerId)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = _customerDomain.Get(customerId);
                response.Data = _mapper.Map<CustomerDto>(customer);
                response.Success = response.Data != null;
                response.Message = response.Success? "Consulta Exitosa" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomerDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customer = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customer);
                response.Success = response.Data != null;
                response.Message = response.Success ? "Consulta Exitosa" : "Ocurrio un error";
                _appLogger.LogInformation(response.Message);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _appLogger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            try
            {
                var customer = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customer);
                response.Success = response.Data != null;
                response.Message = response.Success ? "Consulta Exitosa" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<CustomerDto>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = await _customerDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomerDto>(customer);
                response.Success = response.Data != null;
                response.Message = response.Success ? "Consulta Exitosa" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Insert(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = _customerDomain.Insert(customer);
                response.Success = response.Data;
                response.Message = response.Data ? "Registro Exitoso" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.InsertAsync(customer);
                response.Success = response.Data;
                response.Message = response.Data ? "Registro Exitoso" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = _customerDomain.Update(customer);
                response.Success = response.Data;
                response.Message = response.Data ? "Actualizacion Exitosa" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.UpdateAsync(customer);
                response.Success = response.Data;
                response.Message = response.Data ? "Actualizacion Exitosa" : "Ocurrio un error";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
