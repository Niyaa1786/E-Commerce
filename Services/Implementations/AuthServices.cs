using E_Commerce.DTOs.AuthDTO;
using E_Commerce.Models.Users;
using E_Commerce.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Services.Implementations
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthServices(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email!);
            if (user is null || !user.IsActive) return null;

            var result = await _signInManager.PasswordSignInAsync(user, request.Password!, request.RememberMe, false);

            if (result.Succeeded) 
            {
                var roles = await _userManager.GetRolesAsync(user);
                return roles.FirstOrDefault() ?? "Client";
            }
            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var isExist = await _userManager.FindByEmailAsync(request.Email!);
            if(isExist is not null) return false;


            var newUser = new User()
            {
                UserName = request.UserName ?? request.Email,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName
            };

            try {
                var result = await _userManager.CreateAsync(newUser, request.Password!);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Client");
                    return true;
                }
                return false;
            } catch { return false; }
        }
    }
}
