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
    public class LogController : ControllerBase
    {
        private readonly LogRepositorio _repo;

        public LogController()
        {
            _repo = new LogRepositorio();
        }

        // GET: api/Log
        [HttpGet]
        public IEnumerable<Log> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public Log Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Log
        [HttpPost]
        public Log Post([FromBody] Log log)
        {
            _repo.Incluir(log);
            return log;
        }

        // PUT: api/Log/5
        [HttpPut]
        public Log Put([FromBody] Log log)
        {
            _repo.Alterar(log);
            return log;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Log> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
