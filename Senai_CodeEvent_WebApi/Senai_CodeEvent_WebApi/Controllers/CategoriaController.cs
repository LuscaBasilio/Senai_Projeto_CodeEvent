using Microsoft.AspNetCore.Mvc;
using Senai_CodeEvent_WebApi.Domains;
using Senai_CodeEvent_WebApi.Interfaces;
using Senai_CodeEvent_WebApi.Repositorios;
using System;

namespace Senai_CodeEvent_WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepositorio categoriaRepositorio;

        public CategoriaController()
        {
            categoriaRepositorio = new CategoriaRepositorio();
        }

        [HttpPost]
        public IActionResult CadastrarCategoria(Categorias categoria)
        {
            try
            {
                categoriaRepositorio.CadastrarCategoria(categoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult EditarCategoria(Categorias categoria)
        {
            try
            {
                categoriaRepositorio.EditarCategoria(categoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult ListarCategorias()
        {
            try
            {
                return Ok(categoriaRepositorio.ListarCategorias());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}