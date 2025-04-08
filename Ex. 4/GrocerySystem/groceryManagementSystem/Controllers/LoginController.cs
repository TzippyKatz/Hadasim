using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Dto;
using Service.Interfaces;
using Service.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace groceryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        // POST api/<UserLoginController>
        [HttpPost]
        public IActionResult Post([FromForm] LoginDto item)
        {
            var user = loginService.Authenticate(item);
            if (user != null)
            {
                var token = loginService.GenerateToken(user);
                return Ok(token);
            }
            return BadRequest("User is not exist");
        }
    }
}