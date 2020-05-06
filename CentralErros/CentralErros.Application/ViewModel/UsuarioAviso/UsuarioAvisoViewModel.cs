namespace CentralErros.Application.ViewModel
{
    public class UsuarioAvisoViewModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public int IdAviso { get; set; }
        public AvisoViewModel Aviso { get; set; }
    }
}
