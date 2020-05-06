using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;

namespace CentralErros.Data.Repositorio
{
    public class UsuarioAplicacaoRepositorio : RepositorioBase<UsuarioAplicacao>, IUsuarioAplicacaoRepositorio
    {
        public UsuarioAplicacaoRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
