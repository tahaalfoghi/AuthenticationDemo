
using AuthDemo.EFCore.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthDemo.Services
{
    public class AuthService : IAuthService
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        public AuthService(UserManager<IdentityUser> userManager, IConfiguration config)
        {

            _userManager = userManager;
            _config = config;
        }
        public async Task<bool> Register(LoginModel user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.UserName
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.UserName);
            if (identityUser is null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public string GenerateToken(LoginModel user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            
            var securityToken = new JwtSecurityToken(
                claims: Claims,
                expires:DateTime.Now.AddMinutes(60),
                issuer:_config.GetSection("JWT:Issuer").Value,
                audience:_config.GetSection("JWT:Audience").Value,
                signingCredentials: signingCred
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
