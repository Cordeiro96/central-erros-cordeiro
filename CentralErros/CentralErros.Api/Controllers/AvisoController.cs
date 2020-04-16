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
    public class AvisoController : ControllerBase
    {
        private readonly IAvisoRepositorio _repo;
        
        public AvisoController(IAvisoRepositorio repo)
        {
            _repo = repo;
        }

        // GET: api/Aviso
        [HttpGet]
        public IEnumerable<Aviso> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Aviso/5
        [HttpGet("{id}")]
        public Aviso Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Aviso
        [HttpPost]
        public Aviso Post([FromBody] Aviso aviso)
        {
            _repo.Incluir(aviso);
            return aviso;
        }

        // PUT: api/Aviso/5
        [HttpPut]
        public Aviso Put([FromBody] Aviso aviso)
        {
            _repo.Alterar(aviso);
            return aviso;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Aviso> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}