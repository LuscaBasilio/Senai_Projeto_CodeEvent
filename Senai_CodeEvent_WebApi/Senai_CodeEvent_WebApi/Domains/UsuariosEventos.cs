using System;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Domains
{
    public partial class UsuariosEventos
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdEvento { get; set; }

        public Eventos IdEventoNavigation { get; set; }
        public Usuarios IdUserNavigation { get; set; }
    }
}
