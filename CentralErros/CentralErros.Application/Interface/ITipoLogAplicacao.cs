using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface ITipoLogAplicacao
    {
        void Incluir(TipoLogViewModel entity);
        void Alterar(TipoLogViewModel entity);
        TipoLogViewModel SelecionarPorId(int id);
        List<TipoLogViewModel> SelecionarTodos();
        void Excluir(int id);
    }
}
