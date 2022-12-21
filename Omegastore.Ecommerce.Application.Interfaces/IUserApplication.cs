using Omegastore.Ecommerce.Application.Dto;
using Omegastore.Ecommerce.Shared.Common;

namespace Omegastore.Ecommerce.Application.Interfaces
{
    public interface IUserApplication
    {
        Response<UserDto> Authenticate(string username, string password);
    }
}
