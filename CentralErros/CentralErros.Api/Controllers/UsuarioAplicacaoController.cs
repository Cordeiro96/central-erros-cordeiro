using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralErros.Data.Repositorio;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAplicacaoController : ControllerBase
    {
        private readonly IUsuarioAplicacaoRepositorio _repo;
        public UsuarioAplicacaoController(IUsuarioAplicacaoRepositorio repo)
        {
            _repo = repo;
        }

        // GET: api/UsuariosAplicacoes
        [HttpGet]
        public IEnumerable<UsuarioAplicacao> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/UsuariosAplicacoes/5
        [HttpGet("{id}")]
        public UsuarioAplicacao Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/UsuariosAplicacoes
        [HttpPost]
        public UsuarioAplicacao Post([FromBody] UsuarioAplicacao usuariosAplicacoes)
        {
            _repo.Incluir(usuariosAplicacoes);
            return usuariosAplicacoes;
        }

        // PUT: api/UsuariosAplicacoes/5
        [HttpPut]
        public UsuarioAplicacao Put([FromBody] UsuarioAplicacao usuariosAplicacoes)
        {
            _repo.Alterar(usuariosAplicacoes);
            return usuariosAplicacoes;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<UsuarioAplicacao> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
