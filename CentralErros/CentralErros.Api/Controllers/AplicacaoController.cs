using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacaoController : ControllerBase
    {
        private readonly IAplicacaoAplicacao _repo;

        public AplicacaoController(IAplicacaoAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/Aplicacao
        [HttpGet]
        public IEnumerable<AplicacaoViewModel> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Aplicacao/5
        [HttpGet("{id}")]
        public AplicacaoViewModel Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Aplicacao
        [HttpPost]
        public AplicacaoViewModel Post([FromBody] AplicacaoViewModel aplicacao)
        {
            _repo.Incluir(aplicacao);
            return aplicacao;
        }

        // PUT: api/Aplicacao/5
        [HttpPut]
        public AplicacaoViewModel Put([FromBody] AplicacaoViewModel aplicacao)
        {
            _repo.Alterar(aplicacao);
            return aplicacao;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<AplicacaoViewModel> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
