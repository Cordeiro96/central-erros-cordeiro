using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IAplicacaoAplicacao
    {
        void Incluir(AplicacaoViewModel entity);

        void Alterar(AplicacaoViewModel entity);

        AplicacaoViewModel SelecionarPorId(int id);

        List<AplicacaoViewModel> SelecionarTodos();

        void Excluir(int id);
    }
}
