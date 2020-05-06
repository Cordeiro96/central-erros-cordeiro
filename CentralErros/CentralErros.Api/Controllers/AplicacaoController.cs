using System;
using System.Collections.Generic;
using System.Linq;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Aplicacao;
using CentralErros.Application.ViewModel.Aplicacao.AplicacaoLogs;
using CentralErros.Application.ViewModel.Aplicacao.UsuarioAplicacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Authorize]
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

        // GET: api/aplicacao/1/usuarios
        [Authorize(Roles = "admin")]
        [HttpGet("{app_id}/usuarios")]
        public ActionResult<AplicacaoUsuarioViewModel_Aplicacao> GetAplicacaoUsuarios(int? app_id)
        {
            if (app_id == null)
                return NoContent();
            return Ok(_repo.ObterAplicacaoUsuarios(app_id.Value));
        }

        // GET: api/aplicacao/1/logs
        [HttpGet("{app_id}/logs")]
        public ActionResult<AplicacaoLogsViewModel_Aplicacao> ObterAplicacaoLogs(int? app_id)
        {
            if (app_id == null)
                return NoContent();
            return Ok(_repo.ObterAplicacaoLogs(app_id.Value));
        }

        // POST: api/Aplicacao
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<AplicacaoSimplesViewModel> Post([FromBody] CadastroAplicacaoViewModel aplicacao)
        {
            var idUsuario = HttpContext.User.Claims.ToList()[0].Value;
            var aplicacaoViewModel = _repo.Incluir(aplicacao, idUsuario);
            return Ok(aplicacaoViewModel);
        }

        // PUT: api/Aplicacao
        [Authorize(Roles = "admin")]
        [HttpPut]
        public ActionResult<AplicacaoSimplesViewModel> Put([FromBody] AplicacaoSimplesViewModel aplicacao)
        {
            _repo.Alterar(aplicacao);
            return Ok(_repo.ObterAplicacaoId(aplicacao.Id));
        }

        [Authorize(Roles = "admin")]
        // DELETE: api/Aplicacao/1
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            _repo.Excluir(id);
            return Ok("Aplicação excluída com sucesso!");
        }
    }
}
