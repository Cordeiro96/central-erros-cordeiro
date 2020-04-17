using System;

namespace CentralErros.Application.ViewModel
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int IdTipoLog { get; set; }
        public TipoLogViewModel TipoLog { get; set; }
        public int IdAplicacao { get; set; }
        public AplicacaoViewModel Aplicacao { get; set; }
    }
}
