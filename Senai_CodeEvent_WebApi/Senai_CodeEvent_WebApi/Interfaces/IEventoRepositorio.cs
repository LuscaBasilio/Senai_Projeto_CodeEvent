using Senai_CodeEvent_WebApi.Domains;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Interfaces
{
    public interface IEventoRepositorio
    {
        void CadastrarEvento(Eventos evento);

        List<Eventos> ListarEventos();

        void EditarEvento(Eventos evento);

        List<Interessados> Interessados(int id);
    }
}
