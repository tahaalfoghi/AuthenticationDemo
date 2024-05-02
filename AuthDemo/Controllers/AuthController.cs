using AuthDemo.EFCore.Model;
using AuthDemo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(IAuthService authService, UserManager<IdentityUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _authService.Register(user))
            {
                return Ok("Successfuly done");
            }
            return BadRequest();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _authService.Login(user))
            {
                var tokenString = _authService.GenerateToken(user);
                return Ok(tokenString); 
            }
            else
                return BadRequest("User Faild to login");
        }
        
    }
}
