using System;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Domains
{
    public partial class Eventos
    {
        public Eventos()
        {
            Interessados = new HashSet<Interessados>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public int Categoria { get; set; }
        public int Capacidade { get; set; }
        public bool? Restricao { get; set; }
        public string Imagem { get; set; }
        public string Endereco { get; set; }

        public Categorias CategoriaNavigation { get; set; }
        public ICollection<Interessados> Interessados { get; set; }
    }
}
