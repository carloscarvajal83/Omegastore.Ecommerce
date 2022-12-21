using System;
using FluentValidation;
using Omegastore.Ecommerce.Application.Dto;

namespace Omegastore.Ecommerce.Application.Validators
{
    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
