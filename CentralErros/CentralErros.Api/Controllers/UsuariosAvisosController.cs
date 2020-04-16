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
    public class UsuariosAvisosController : ControllerBase
    {
        private readonly UsuariosAvisosRepositorio _repo;
        public UsuariosAvisosController()
        {
            _repo = new UsuariosAvisosRepositorio();
        }

        // GET: api/UsuariosAvisos
        [HttpGet]
        public IEnumerable<UsuariosAvisos> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/UsuariosAvisos/5
        [HttpGet("{id}")]
        public UsuariosAvisos Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/UsuariosAvisos
        [HttpPost]
        public UsuariosAvisos Post([FromBody] UsuariosAvisos usuariosAvisos)
        {
            _repo.Incluir(usuariosAvisos);
            return usuariosAvisos;
        }

        // PUT: api/UsuariosAvisos/5
        [HttpPut("{id}")]
        public UsuariosAvisos Put([FromBody] UsuariosAvisos usuariosAvisos)
        {
            _repo.Alterar(usuariosAvisos);
            return usuariosAvisos;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<UsuariosAvisos> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
