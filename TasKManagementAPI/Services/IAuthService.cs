using TasKManagementAPI.DTOs;

namespace TasKManagementAPI.Services
{
    public interface IAuthService
    {

        Task<UserReasponseDto> RegisterAsync(RegisterDto registerDto);
    }
}
