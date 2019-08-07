using Senai_CodeEvent_WebApi.Domains;
using System.Collections.Generic;

namespace Senai_CodeEvent_WebApi.Interfaces
{
    public interface ICategoriaRepositorio
    {
        void CadastrarCategoria(Categoria categoria);

        List<Categoria> ListarCategorias();

        void EditarCategoria(Categoria categoria);
    }
}
