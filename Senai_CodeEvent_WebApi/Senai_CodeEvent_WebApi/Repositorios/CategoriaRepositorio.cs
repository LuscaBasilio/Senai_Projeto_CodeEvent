using Senai_CodeEvent_WebApi.Domains;
using Senai_CodeEvent_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai_CodeEvent_WebApi.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public void CadastrarCategoria(Categoria categoria)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                ctx.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public void EditarCategoria(Categoria categoria)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                Categoria categoriaExiste = ctx.Categoria.Find(categoria.Id);

                if(categoriaExiste != null)
                {
                    categoriaExiste.Nome = categoria.Nome;
                    ctx.Categoria.Update(categoriaExiste);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Categoria> ListarCategorias()
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                return ctx.Categoria.ToList();
            }
        }
    }
}
