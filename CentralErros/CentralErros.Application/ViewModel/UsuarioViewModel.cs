using System.Collections.Generic;

namespace CentralErros.Application.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Nivel { get; set; }
        public List<UsuarioAvisoViewModel> UsuariosAvisos { get; set; }
        public List<UsuarioAplicacaoViewModel> UsuariosAplicacoes { get; set; }
    }
}
