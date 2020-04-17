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
        public IEnumerable<AvisoViewModel> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Aviso/5
        [HttpGet("{id}")]
        public AvisoViewModel Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Aviso
        [HttpPost]
        public AvisoViewModel Post([FromBody] AvisoViewModel aviso)
        {
            _repo.Incluir(aviso);
            return aviso;
        }

        // PUT: api/Aviso/5
        [HttpPut]
        public AvisoViewModel Put([FromBody] AvisoViewModel aviso)
        {
            _repo.Alterar(aviso);
            return aviso;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<AvisoViewModel> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}