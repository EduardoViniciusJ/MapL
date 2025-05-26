using MapL.DTOs;
using MapL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Users>? _userManager;
        private readonly RoleManager<Users>? _roleManager;

        public AuthController(UserManager<Users>? userManager, RoleManager<Users>? roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO userDTO)
        {
            var user = await _userManager.FindByNameAsync(userDTO.Username);
            if (user is null && await _userManager.CheckPasswordAsync(user, userDTO.Password))
            {
                return BadRequest("Usuário não encontrado ou nome de usuário e senha inválidos.");
            }

            return Ok($"Usuário logado com sucesso {user.Email} e {user.UserName}");

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginDTO userDTO)
        {

        }



    }
}
