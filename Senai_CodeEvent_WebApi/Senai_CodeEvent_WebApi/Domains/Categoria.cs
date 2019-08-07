using System;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Eventos = new HashSet<Eventos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Eventos> Eventos { get; set; }
    }
}
