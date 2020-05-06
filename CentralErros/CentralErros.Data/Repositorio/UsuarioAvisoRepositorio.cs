using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;

namespace CentralErros.Data.Repositorio
{
    public class UsuarioAvisoRepositorio : RepositorioBase<UsuarioAviso>, IUsuarioAvisoRepositorio
    {
        public UsuarioAvisoRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
