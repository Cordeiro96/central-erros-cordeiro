using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Domain.Modelo
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Nivel { get; set; }
        public List<UsuarioAviso> UsuariosAvisos { get; set; }
        public List<UsuarioAplicacao> UsuariosAplicacoes { get; set; }
    }
}
