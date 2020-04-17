using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogAplicacao _repo;

        public LogController(ILogAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/Log
        [HttpGet]
        public IEnumerable<LogViewModel> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public LogViewModel Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Log
        [HttpPost]
        public LogViewModel Post([FromBody] LogViewModel log)
        {
            _repo.Incluir(log);
            return log;
        }

        // PUT: api/Log/5
        [HttpPut]
        public LogViewModel Put([FromBody] LogViewModel log)
        {
            _repo.Alterar(log);
            return log;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<LogViewModel> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
