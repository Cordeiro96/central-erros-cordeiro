using CentralErros.Domain.Repositorio;

namespace CentralErros.Domain.Modelo
{
    public class UsuarioAviso : IEntity
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdAviso { get; set; }
        public Aviso Aviso { get; set; }
    }
}
