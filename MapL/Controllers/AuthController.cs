using MapL.DTOs;
using MapL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole>? _roleManager;

        public AuthController(UserManager<Users> userManager, RoleManager<IdentityRole>? roleManager)
        {
            Console.WriteLine("AuthController foi construído!");
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
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var userExiste = await _userManager.FindByNameAsync(registerDTO.Username);

            if(userExiste != null)
            {
                return Conflict(new {message = "Usuário já existe."});
            }

            Users user = new()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Erro ao criar a conta.",
                    errors = result.Errors.Select(e=> e.Description)
                });
            }

            return Created("", new
            {
                message = "Usuário criado com sucesso.",
                username = user.UserName,
                email = user.Email
            });
        }
    }
}
