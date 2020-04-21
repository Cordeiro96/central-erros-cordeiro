using System;
using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _repo;

        public UsuarioController(IUsuarioAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/Usuario
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioViewModel>> Get()
        {
            return Ok(_repo.ObterTodosUsuarios());
        }

        // GET: api/Usuario/5
        [HttpGet("id/{id}")]
        public ActionResult<UsuarioViewModel> GetUserId(int? id)
        {
            if (id == null)
                return NoContent();

            return _repo.ObterUsuarioId(Convert.ToInt32(id));
        }

        [HttpGet("nome/{nome}")]
        public ActionResult<IEnumerable<UsuarioViewModel>> GetUserNome(string nome)
        {
            if (nome == null)
                return NoContent();
            
            return Ok(_repo.ObterUsuarioNome(nome));
        }

        // POST: api/Usuario
        [HttpPost]
        public ActionResult<UsuarioViewModel> Post([FromBody] UsuarioViewModel usuario)
        {
            usuario.Id = 0;
            _repo.Incluir(usuario);
            return Ok(usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public ActionResult<UsuarioViewModel> Put([FromBody] UsuarioViewModel usuario)
        {
            if (usuario.Id == 0)
                return NoContent();
            _repo.Alterar(usuario);
            return Ok(_repo.ObterUsuarioId(usuario.Id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<List<UsuarioViewModel>> Delete(int id)
        {
            _repo.Excluir(id);
            return Ok(_repo.ObterTodosUsuarios());
        }
    }
}
