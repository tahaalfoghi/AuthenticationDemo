using AuthDemo.EFCore.Model;

namespace AuthDemo.Services
{
    public interface IAuthService
    {
        Task<bool> Register(LoginModel user);
        Task<bool> Login(LoginModel user);
        string GenerateToken(LoginModel user);
    }
}
