﻿using MapL.DTOs;
using MapL.Models;
using MapL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MapL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole>? _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<Users> userManager, RoleManager<IdentityRole>? roleManager, ITokenService tokenService, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            // Procura o usuário com base no seu username.
            var user = await _userManager.FindByNameAsync(loginDTO.Username);

            // Valida o usuário se ele existe e se suas credenciais estão certas, se não retorna Http 401
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return Unauthorized(new { message = "Username ou senha incorretos." });
            }
      
            // Define as claims do usuário
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginDTO.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),             
          
            };

            // Adicionando as roles as claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }      

            // Cria o token de acesso
            var token = _tokenService.GenerateAccessToken(authClaims, _configuration);

            // Http 200
            return Ok(new
            {
                message = "Usuário logado com sucesso",
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Registro([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            // Procura o usuário com base no seu username.
            var userExiste = await _userManager.FindByNameAsync(registerDTO.Username);

            // Valida se existe um usuário com o username fornecido, retornando Http 409 caso exista.
            if (userExiste != null)
            {
                return Conflict(new { message = "Usuário já existe." });
            }

            // Cria o usuário com base nas credenciais fornecidas. 
            Users user = new()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            var role = await _userManager.AddToRoleAsync(user, "user");
            var tokenEmail = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                                                                        
            // Se usuário não colocou as credencias conforme as regras do Identity, retorna Http 400
            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Erro ao criar a conta.",
                    errors = result.Errors.Select(e => e.Description)
                });
            }

            // Http 201
            return Created("", new
            {
                message = "Usuário criado com sucesso.",
                username = user.UserName,
                email = user.Email
            });
        }

     


    }
}
