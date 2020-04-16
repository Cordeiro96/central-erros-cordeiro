using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Domain.Modelo
{
    public class UsuariosAplicacoes : IEntity
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdAplicacao { get; set; }
        public Aplicacao Aplicacao { get; set; }
    }
}
