using Senai_CodeEvent_WebApi.Domains;
using Senai_CodeEvent_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai_CodeEvent_WebApi.Repositorios
{
    public class EventoRepositorio : IEventoRepositorio
    {
        public void CadastrarEvento(Eventos evento)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                ctx.Add(evento);
                ctx.SaveChanges();
            }
        }

        public void EditarEvento(Eventos evento)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                Eventos eventoExiste = ctx.Eventos.Find(evento.Id);

                if(eventoExiste != null)
                {
                    eventoExiste = evento;
                    ctx.Eventos.Update(eventoExiste);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Eventos> ListarEventos()
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                return ctx.Eventos.ToList();
            }
        }

        public List<Usuarios> Interessados(int id)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                return null;//UsuariosEventos evento = ctx.UsuariosEventos.Where(x => x.IdEvento == id).ToList();
            }
        }
    }
}
