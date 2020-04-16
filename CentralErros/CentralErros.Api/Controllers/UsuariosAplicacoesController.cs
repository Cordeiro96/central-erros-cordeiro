using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralErros.Data.Repositorio;
using CentralErros.Domain.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosAplicacoesController : ControllerBase
    {
        private readonly UsuariosAplicacoesRepositorio _repo;
        public UsuariosAplicacoesController()
        {
            _repo = new UsuariosAplicacoesRepositorio();
        }

        // GET: api/UsuariosAplicacoes
        [HttpGet]
        public IEnumerable<UsuariosAplicacoes> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/UsuariosAplicacoes/5
        [HttpGet("{id}")]
        public UsuariosAplicacoes Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/UsuariosAplicacoes
        [HttpPost]
        public UsuariosAplicacoes Post([FromBody] UsuariosAplicacoes usuariosAplicacoes)
        {
            _repo.Incluir(usuariosAplicacoes);
            return usuariosAplicacoes;
        }

        // PUT: api/UsuariosAplicacoes/5
        [HttpPut]
        public UsuariosAplicacoes Put([FromBody] UsuariosAplicacoes usuariosAplicacoes)
        {
            _repo.Alterar(usuariosAplicacoes);
            return usuariosAplicacoes;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<UsuariosAplicacoes> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
