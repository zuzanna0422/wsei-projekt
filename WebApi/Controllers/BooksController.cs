using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Infrastructure.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KickstarterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Bearer")]
    public class BooksController(UserManager<UserEntity> _userManager) : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get()
        {
            Console.WriteLine(GetCurrentUser().Email);
            return Ok(
                new
                {
                    Title ="C#",
                    Author ="Freeman",
                });
        }

        private UserEntity GetCurrentUser()
        {
            var idn =HttpContext.User.Identity as ClaimsIdentity;
            if (idn != null)
            {
                string? name = idn.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                return _userManager.FindByIdAsync(name).Result;
            }
            return null;
        }
            
    }
    
}