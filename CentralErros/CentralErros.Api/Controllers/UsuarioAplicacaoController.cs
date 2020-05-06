using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAplicacaoController : ControllerBase
    {
        private readonly IUsuarioAplicacaoAplicacao _repo;
        public UsuarioAplicacaoController(IUsuarioAplicacaoAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/UsuariosAplicacoes
        [HttpGet]
        public IEnumerable<UsuarioAplicacaoViewModel> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/UsuariosAplicacoes/5
        [HttpGet("{id}")]
        public UsuarioAplicacaoViewModel Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/UsuariosAplicacoes
        [HttpPost]
        public UsuarioAplicacaoViewModel Post([FromBody] UsuarioAplicacaoViewModel usuariosAplicacoes)
        {
            _repo.Incluir(usuariosAplicacoes);
            return usuariosAplicacoes;
        }

        // PUT: api/UsuariosAplicacoes/5
        [HttpPut]
        public UsuarioAplicacaoViewModel Put([FromBody] UsuarioAplicacaoViewModel usuariosAplicacoes)
        {
            _repo.Alterar(usuariosAplicacoes);
            return usuariosAplicacoes;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<UsuarioAplicacaoViewModel> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
