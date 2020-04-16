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
    public class AplicacaoController : ControllerBase
    {
        private readonly AplicacaoRepositorio _repo;

        public AplicacaoController()
        {
            _repo = new AplicacaoRepositorio();
        }

        // GET: api/Aplicacao
        [HttpGet]
        public IEnumerable<Aplicacao> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Aplicacao/5
        [HttpGet("{id}")]
        public Aplicacao Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Aplicacao
        [HttpPost]
        public Aplicacao Post([FromBody] Aplicacao aplicacao)
        {
            _repo.Incluir(aplicacao);
            return aplicacao;
        }

        // PUT: api/Aplicacao/5
        [HttpPut]
        public Aplicacao Put([FromBody] Aplicacao aplicacao)
        {
            _repo.Alterar(aplicacao);
            return aplicacao;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Aplicacao> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
