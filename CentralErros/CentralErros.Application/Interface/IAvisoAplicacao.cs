using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IAvisoAplicacao
    {
        void Incluir(AvisoViewModel entity);

        void Alterar(AvisoViewModel entity);

        AvisoViewModel SelecionarPorId(int id);

        List<AvisoViewModel> SelecionarTodos();

        void Excluir(int id);
    }
}
