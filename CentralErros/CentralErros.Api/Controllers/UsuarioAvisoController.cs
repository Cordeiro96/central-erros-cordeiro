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
    public class UsuarioAvisoController : ControllerBase
    {
        private readonly IUsuarioAvisoRepositorio _repo;
        public UsuarioAvisoController(IUsuarioAvisoRepositorio repo)
        {
            _repo = repo;
        }

        // GET: api/UsuariosAvisos
        [HttpGet]
        public IEnumerable<UsuarioAviso> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/UsuariosAvisos/5
        [HttpGet("{id}")]
        public UsuarioAviso Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/UsuariosAvisos
        [HttpPost]
        public UsuarioAviso Post([FromBody] UsuarioAviso usuariosAvisos)
        {
            _repo.Incluir(usuariosAvisos);
            return usuariosAvisos;
        }

        // PUT: api/UsuariosAvisos/5
        [HttpPut("{id}")]
        public UsuarioAviso Put([FromBody] UsuarioAviso usuariosAvisos)
        {
            _repo.Alterar(usuariosAvisos);
            return usuariosAvisos;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<UsuarioAviso> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
