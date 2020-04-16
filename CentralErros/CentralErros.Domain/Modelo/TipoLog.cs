using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Domain.Modelo
{
    public class TipoLog : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Log> Logs { get; set; }
    }
}
