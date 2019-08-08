﻿using System;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuariosEventos = new HashSet<UsuariosEventos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<UsuariosEventos> UsuariosEventos { get; set; }
    }
}
