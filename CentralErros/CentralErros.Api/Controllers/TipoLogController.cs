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
    public class TipoLogController : ControllerBase
    {
        private readonly TipoLogRepositorio _repo;
        public TipoLogController()
        {
            _repo = new TipoLogRepositorio();
        }

        // GET: api/TipoLog
        [HttpGet]
        public IEnumerable<TipoLog> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/TipoLog/5
        [HttpGet("{id}")]
        public TipoLog Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/TipoLog
        [HttpPost]
        public TipoLog Post([FromBody] TipoLog tipoLog)
        {
            _repo.Incluir(tipoLog);
            return tipoLog;
        }

        // PUT: api/TipoLog/5
        [HttpPut("{id}")]
        public TipoLog Put( [FromBody] TipoLog tipoLog)
        {
            _repo.Alterar(tipoLog);
            return tipoLog;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<TipoLog> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
