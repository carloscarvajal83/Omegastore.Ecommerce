using AutoMapper;
using Omegastore.Ecommerce.Application.Dto;
using Omegastore.Ecommerce.Application.Interfaces;
using Omegastore.Ecommerce.Application.Validators;
using Omegastore.Ecommerce.Domain.Interfaces;
using Omegastore.Ecommerce.Shared.Common;
using System;

namespace Omegastore.Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _userDtoValidator;

        public UserApplication(IUserDomain userDomain, IMapper mapper, UserDtoValidator userDtoValidator)
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
        }

        public Response<UserDto> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();
            var validation = _userDtoValidator.Validate(new UserDto { UserName = username, Password = password });
            if (!validation.IsValid) {
                response.Message = "Validation Errors";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _userDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.Success = true;
                response.Message = "Successfully logged in";
            }
            catch (InvalidOperationException) {
                response.Success = true;
                response.Message = "Wrong user or password";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
