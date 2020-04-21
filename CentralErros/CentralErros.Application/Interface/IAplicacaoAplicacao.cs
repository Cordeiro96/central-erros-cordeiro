using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IAplicacaoAplicacao
    {
        void Incluir(AplicacaoViewModel entity);

        void Alterar(AplicacaoViewModel entity);

        void Excluir(int id);

        List<AplicacaoViewModel> ObterTodosAplicacoes();

        AplicacaoViewModel ObterAplicacaoId(int id);

        List<AplicacaoViewModel> ObterAplicacaoNome(string nome);

        AplicacaoViewModel ObterAplicacaoTipoLog(int app_id, int tipolog_id);
    }
}
