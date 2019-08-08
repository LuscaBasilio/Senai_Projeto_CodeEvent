using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_CodeEvent_WebApi.Domains;
using Senai_CodeEvent_WebApi.Interfaces;
using Senai_CodeEvent_WebApi.Repositorios;
using Senai_CodeEvent_WebApi.ViewModels;

namespace Senai_CodeEvent_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioController()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuario = usuarioRepositorio.Login(login.Email, login.Senha);
                if (usuario == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Não Encontrado"
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email)
                };

                SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("CodeEventsSecurityKey"));

                SigningCredentials credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: null,//"CodeEvent",
                    audience: null,//"CodeEvent",
                    claims: claims,
                    expires: null,
                    signingCredentials: credential
                    );
                return Ok(new { Mensagem = "Ta na mão", Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
        [HttpPost("Presenca")]
        public IActionResult MarcarPresenca(Interessados UsuarioEvento)
        {
            try
            {
                usuarioRepositorio.MarcarPresenca(UsuarioEvento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}