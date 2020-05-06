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
    public class UsuarioAvisoController : ControllerBase
    {
        private readonly IUsuarioAvisoAplicacao _repo;
        public UsuarioAvisoController(IUsuarioAvisoAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/UsuariosAvisos
        [HttpGet]
        public IEnumerable<UsuarioAvisoViewModel> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/UsuariosAvisos/5
        [HttpGet("{id}")]
        public UsuarioAvisoViewModel Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/UsuariosAvisos
        [HttpPost]
        public UsuarioAvisoViewModel Post([FromBody] UsuarioAvisoViewModel usuariosAvisos)
        {
            _repo.Incluir(usuariosAvisos);
            return usuariosAvisos;
        }

        // PUT: api/UsuariosAvisos/5
        [HttpPut("{id}")]
        public UsuarioAvisoViewModel Put([FromBody] UsuarioAvisoViewModel usuariosAvisos)
        {
            _repo.Alterar(usuariosAvisos);
            return usuariosAvisos;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<UsuarioAvisoViewModel> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
