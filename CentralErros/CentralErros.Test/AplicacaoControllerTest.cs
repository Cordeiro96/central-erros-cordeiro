using CentralErros.Api.Controllers;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel.Aplicacao;
using CentralErros.Data;
using CentralErros.Domain.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CentralErros.Test
{
    public class AplicacaoControllerTest
    {
        //private readonly Mock<DbSet<Aplicacao>> _mockSet;
        //private readonly Mock<Contexto> _mockContext;
        private readonly Mock<IAplicacaoAplicacao> _mockApp;
        //private readonly Aplicacao _aplicacao;

        public AplicacaoControllerTest()
        {
            //_mockSet = new Mock<DbSet<Aplicacao>>();
            //_mockContext = new Mock<Contexto>();
            _mockApp = new Mock<IAplicacaoAplicacao>();
            //_aplicacao = new Aplicacao() { Id = 1, Nome = "Teste", Descricao = "Teste de software" };
        }

        [Fact]
        public async Task GetAplicacaoId()
        {
            var service = new AplicacaoController(_mockApp.Object);

            service.GetAppId(1);

            //Verifica se o método ObterAplicacaoId executou apenas uma vez
            _mockApp.Verify(x => x.ObterAplicacaoId(1), Times.Once());
        }

        [Fact]
        public async Task GetAplicacaoIdErro()
        {
            var service = new AplicacaoController(_mockApp.Object);

            var result = service.GetAppId(null);

            //var okResult = result as NoContentResult();
        }
    }
}