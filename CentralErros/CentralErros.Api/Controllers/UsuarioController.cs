using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _repo;

        public UsuarioController(IUsuarioAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioViewModel> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public UsuarioViewModel Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Usuario
        [HttpPost]
        public UsuarioViewModel Post([FromBody] UsuarioViewModel usuario)
        {
            _repo.Incluir(usuario);
            return usuario;
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public UsuarioViewModel Put([FromBody] UsuarioViewModel usuario)
        {
            _repo.Alterar(usuario);
            return usuario;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<UsuarioViewModel> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
