using RPG.Dtos;
using RPG.Dtos.Users;

namespace RPG.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<int>> Register(UserRegisterDto request);
        Task<ApiResponse<string>> Login(UserLoginDto request);
    }
}