using Microsoft.AspNetCore.Mvc;
using Senai_CodeEvent_WebApi.Domains;
using Senai_CodeEvent_WebApi.Interfaces;
using Senai_CodeEvent_WebApi.Repositorios;
using System;

namespace Senai_CodeEvent_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IEventoRepositorio eventoRepositorio;

        public EventoController()
        {
            eventoRepositorio = new EventoRepositorio();
        }

        [HttpPost]
        public IActionResult CadastrarEvento(Eventos evento)
        {
            try
            {
                eventoRepositorio.CadastrarEvento(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult EditarEvento(Eventos evento)
        {
            try
            {
                eventoRepositorio.EditarEvento(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult ListarEventos()
        {
            try
            {
                return Ok(eventoRepositorio.ListarEventos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpGet]
        //public IActionResult Interessados()
        //{
        //    try
        //    {
        //        return Ok(eventoRepositorio.Interessados());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}