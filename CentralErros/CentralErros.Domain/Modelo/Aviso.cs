using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;

namespace CentralErros.Domain.Modelo
{
    public class Aviso : IEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int IdTipoLog { get; set; }
        public TipoLog TipoLog { get; set; }
        public List<UsuarioAviso> UsuariosAvisos { get; set; }
    }
}
