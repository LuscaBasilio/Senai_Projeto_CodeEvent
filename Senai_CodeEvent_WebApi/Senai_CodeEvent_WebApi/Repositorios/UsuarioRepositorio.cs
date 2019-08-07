using Senai_CodeEvent_WebApi.Domains;
using System.Linq;
using Senai_CodeEvent_WebApi.Interfaces;

namespace Senai_CodeEvent_WebApi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuarios Login(string email, string senha)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            }
        }
    }
}
