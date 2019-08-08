using Microsoft.EntityFrameworkCore;
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
                Eventos eventoExiste = ctx.Eventos.FirstOrDefault(x => x.Id == evento.Id);

                if(eventoExiste != null)
                {
                    eventoExiste.Titulo = evento.Titulo;
                    eventoExiste.Descricao = evento.Descricao;
                    eventoExiste.DataEvento = evento.DataEvento;
                    eventoExiste.Categoria = evento.Categoria;
                    eventoExiste.Capacidade = evento.Capacidade;
                    eventoExiste.Restricao = evento.Restricao;
                    eventoExiste.Imagem = evento.Imagem;
                    eventoExiste.Endereco = evento.Endereco;

                    ctx.Eventos.Update(eventoExiste);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Eventos> ListarEventos()
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                return ctx.Eventos.Include(x => x.CategoriaNavigation).ToList();
            }
        }

        public List<Interessados> Interessados(int id)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                return ctx.Interessados.Where(x => x.IdEvento == id).ToList();
            }
        }
    }
}
