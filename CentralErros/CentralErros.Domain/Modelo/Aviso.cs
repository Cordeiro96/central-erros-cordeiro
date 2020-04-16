using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Domain.Modelo
{
    public class Aviso : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Visualizado { get; set; }
        public DateTime Data { get; set; }
        public List<UsuarioAviso> UsuariosAvisos { get; set; }
    }
}
