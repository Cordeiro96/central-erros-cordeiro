using CentralErros.Application.ViewModel.Aviso;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.ViewModel
{
    public class AvisoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Visualizado { get; set; }
        public DateTime Data { get; set; }
        public List<UsuarioViewModel_Aviso> Usuarios { get; set; }
    }
}
