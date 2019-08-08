using Senai_CodeEvent_WebApi.Domains;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Interfaces
{
    public interface ICategoriaRepositorio
    {
        void CadastrarCategoria(Categorias categoria);

        List<Categorias> ListarCategorias();

        void EditarCategoria(Categorias categoria);
    }
}
