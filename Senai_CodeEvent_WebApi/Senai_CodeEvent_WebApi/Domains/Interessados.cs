using System;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Domains
{
    public partial class Interessados
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int IdEvento { get; set; }

        public Eventos IdEventoNavigation { get; set; }
    }
}
