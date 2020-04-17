using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLogController : ControllerBase
    {
        private readonly ITipoLogAplicacao _repo;
        public TipoLogController(ITipoLogAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/TipoLog
        [HttpGet]
        public IEnumerable<TipoLogViewModel> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/TipoLog/5
        [HttpGet("{id}")]
        public TipoLogViewModel Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/TipoLog
        [HttpPost]
        public TipoLogViewModel Post([FromBody] TipoLogViewModel tipoLog)
        {
            _repo.Incluir(tipoLog);
            return tipoLog;
        }

        // PUT: api/TipoLog/5
        [HttpPut("{id}")]
        public TipoLogViewModel Put( [FromBody] TipoLogViewModel tipoLog)
        {
            _repo.Alterar(tipoLog);
            return tipoLog;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<TipoLogViewModel> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
