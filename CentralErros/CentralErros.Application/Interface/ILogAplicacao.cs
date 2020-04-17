using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface ILogAplicacao
    {
        void Incluir(LogViewModel entity);
        void Alterar(LogViewModel entity);
        LogViewModel SelecionarPorId(int id);
        List<LogViewModel> SelecionarTodos();
        void Excluir(int id);
    }
}
