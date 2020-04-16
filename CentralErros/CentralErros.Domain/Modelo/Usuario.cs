using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Domain.Modelo
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Nivel { get; set; }
        public List<UsuariosAvisos> UsuariosAvisos { get; set; }
        public List<UsuariosAplicacoes> UsuariosAplicacoes { get; set; }
    }
}
