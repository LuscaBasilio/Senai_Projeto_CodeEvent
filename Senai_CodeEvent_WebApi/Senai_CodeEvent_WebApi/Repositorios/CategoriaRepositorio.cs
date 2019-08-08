using Senai_CodeEvent_WebApi.Domains;
using Senai_CodeEvent_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Senai_CodeEvent_WebApi.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        public void CadastrarCategoria(Categorias categoria)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                ctx.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public void EditarCategoria(Categorias categoria)
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                Categorias categoriaExiste = ctx.Categorias.Find(categoria.Id);

                if(categoriaExiste != null)
                {
                    categoriaExiste.Nome = categoria.Nome;
                    ctx.Categorias.Update(categoriaExiste);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Categorias> ListarCategorias()
        {
            using (CodeEventsContext ctx = new CodeEventsContext())
            {
                return ctx.Categorias.ToList();
            }
        }
    }
}
