using E_Commerce.DTOs.AuthDTO;

namespace E_Commerce.Services.Interfaces
{
    public interface IAuthServices
    {
        public Task<bool> Register(RegisterRequest request);
        public Task<string> Login(LoginRequest request);
        public Task Logout();
        public bool IsAuthenticated();
        
    }
}
