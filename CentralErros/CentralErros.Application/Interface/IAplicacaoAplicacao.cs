using CentralErros.Application.ViewModel;
using CentralErros.Application.ViewModel.Aplicacao;
using CentralErros.Application.ViewModel.Aplicacao.AplicacaoLogs;
using CentralErros.Application.ViewModel.Aplicacao.UsuarioAplicacao;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IAplicacaoAplicacao
    {
        AplicacaoSimplesViewModel Incluir(CadastroAplicacaoViewModel entity, string idUsuario);
        void Alterar(AplicacaoSimplesViewModel entity);
        void Excluir(int id);
        AplicacaoUsuarioViewModel_Aplicacao ObterAplicacaoUsuarios(int idAplicacao);
        AplicacaoLogsViewModel_Aplicacao ObterAplicacaoLogs(int idAplicacao);
        List<AplicacaoViewModel> ObterTodosAplicacoes();
        AplicacaoViewModel ObterAplicacaoId(int id);
        List<AplicacaoViewModel> ObterAplicacaoNome(string nome);
        AplicacaoViewModel ObterAplicacaoTipoLog(int app_id, int tipolog_id);
    }
}
