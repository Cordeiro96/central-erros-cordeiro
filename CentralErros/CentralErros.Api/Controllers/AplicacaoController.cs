using System;
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
        public ActionResult<IEnumerable<AplicacaoViewModel>> Get()
        {
            return Ok(_repo.ObterTodosAplicacoes());
        }

        // GET: api/Aplicacao/5
        [HttpGet("id/{id}")]
        public ActionResult<AplicacaoViewModel> GetAppId(int? id)
        {
            if (id == null)
                return NoContent();

            return Ok(_repo.ObterAplicacaoId(Convert.ToInt32(id)));
        }

        [HttpGet("nome/{nome}")]
        public ActionResult<IEnumerable<AplicacaoViewModel>> GetAppNome(string nome)
        {
            if (nome == null)
                return NoContent();

            return Ok(_repo.ObterAplicacaoNome(nome));
        }

        [HttpGet("{app_id}/tipolog/{tipolog_id}")]
        public ActionResult<IEnumerable<AplicacaoViewModel>> GetTipoLog(int? app_id, int? tipolog_id)
        {
            if (app_id == null || tipolog_id == null)
                return NoContent();

            return Ok(_repo.ObterAplicacaoTipoLog(Convert.ToInt32(app_id), Convert.ToInt32(tipolog_id)));
        }

        // POST: api/Aplicacao
        [HttpPost]
        public ActionResult<AplicacaoViewModel> Post([FromBody] AplicacaoViewModel aplicacao)
        {
            aplicacao.Id = 0;
            _repo.Incluir(aplicacao);
            return Ok(aplicacao);
        }

        // PUT: api/Aplicacao/5
        [HttpPut]
        public ActionResult<AplicacaoViewModel> Put([FromBody] AplicacaoViewModel aplicacao)
        {
            _repo.Alterar(aplicacao);
            return Ok(_repo.ObterAplicacaoId(aplicacao.Id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<List<AplicacaoViewModel>> Delete(int id)
        {
            _repo.Excluir(id);
            return Ok(_repo.ObterTodosAplicacoes());
        }
    }
}
