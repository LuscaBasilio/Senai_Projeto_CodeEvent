using Senai_CodeEvent_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senai_CodeEvent_WebApi.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuarios Login(string email, string senha);

        void MarcarPresenca(UsuariosEventos UsuarioEvento);
    }
}
