namespace CentralErros.Application.ViewModel
{
    public class UsuarioAplicacaoViewModel
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public int IdAplicacao { get; set; }
        public AplicacaoViewModel Aplicacao { get; set; }
    }
}
