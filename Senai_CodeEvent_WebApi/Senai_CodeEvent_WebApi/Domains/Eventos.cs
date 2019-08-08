using System;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Domains
{
    public partial class Eventos
    {
        public Eventos()
        {
            UsuariosEventos = new HashSet<UsuariosEventos>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public int? Categorias { get; set; }
        public int Capacidade { get; set; }
        public bool? Restricao { get; set; }
        public string Imagem { get; set; }
        public string Endereco { get; set; }

        public Categorias CategoriasNavigation { get; set; }
        public ICollection<UsuariosEventos> UsuariosEventos { get; set; }
    }
}
