using System;
using System.Collections.Generic;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvisoController : ControllerBase
    {
        private readonly IAvisoAplicacao _repo;
        
        public AvisoController(IAvisoAplicacao repo)
        {
            _repo = repo;
        }

        // GET: api/Aviso
        [HttpGet]
        public ActionResult<IEnumerable<AvisoViewModel>> Get()
        {
            return Ok(_repo.ObterTodosAvisos());
        }

        // GET: api/Aviso/5
        [HttpGet("{id}")]
        public ActionResult<AvisoViewModel> Get(int? id)
        {
            if (id == null)
                return NoContent();

            return Ok(_repo.ObterAvisoId(Convert.ToInt32(id)));
        }

        // POST: api/Aviso
        [HttpPost]
        public ActionResult<AvisoViewModel> Post([FromBody] AvisoViewModel aviso)
        {
            aviso.Id = 0;
            _repo.Incluir(aviso);
            return Ok(aviso);
        }

        // PUT: api/Aviso
        [HttpPut]
        public ActionResult<AvisoViewModel> Put([FromBody] AvisoViewModel aviso)
        {
            _repo.Alterar(aviso);
            return Ok(_repo.ObterAvisoId(aviso.Id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<List<AvisoViewModel>> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.ObterTodosAvisos();
        }
    }
}