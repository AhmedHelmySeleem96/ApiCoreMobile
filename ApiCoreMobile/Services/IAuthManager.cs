using ApiCoreMobile.Models;

namespace ApiCoreMobile.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto userDto);
        Task<string> CreateToken();
    }
}
