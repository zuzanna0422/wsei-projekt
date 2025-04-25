using Infrastructure.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Username);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.Succeeded)
            {
                return Ok(new {message = "Login successful"});
            }
            else
            {
                return BadRequest();
            }           
        }
    }
}
