using System;
using Microsoft.AspNetCore.Mvc;
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
                return null;
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}