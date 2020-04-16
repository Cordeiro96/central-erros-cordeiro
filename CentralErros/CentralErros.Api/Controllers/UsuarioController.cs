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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repo;

        public UsuarioController(IUsuarioRepositorio repo)
        {
            _repo = repo;
        }

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Usuario
        [HttpPost]
        public Usuario Post([FromBody] Usuario usuario)
        {
            _repo.Incluir(usuario);
            return usuario;
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public Usuario Put([FromBody] Usuario usuario)
        {
            _repo.Alterar(usuario);
            return usuario;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Usuario> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
