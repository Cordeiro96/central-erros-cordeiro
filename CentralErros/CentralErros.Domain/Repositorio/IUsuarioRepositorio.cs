using CentralErros.Domain.Modelo;
using System.Collections.Generic;

namespace CentralErros.Domain.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        List<Usuario> ObterTodosUsuarios();
        Usuario ObterUsuarioId(int id);
        List<Usuario> ObterUsuarioNome(string nome);
    }
}
