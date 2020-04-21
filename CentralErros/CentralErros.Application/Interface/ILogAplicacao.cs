using CentralErros.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface ILogAplicacao
    {
        void Incluir(LogViewModel entity);

        void Alterar(LogViewModel entity);

        List<LogViewModel> ObterTodosLogs();

        LogViewModel ObterLogId(int id);

        Object TopLogApp(string filtro);

        Object TopLogAppId(int id_aplicacao);

        void Excluir(int id);
        
    }
}
