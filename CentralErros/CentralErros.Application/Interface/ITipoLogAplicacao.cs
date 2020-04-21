using CentralErros.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface ITipoLogAplicacao
    {
        void Incluir(TipoLogViewModel entity);
        void Alterar(TipoLogViewModel entity);
        List<TipoLogViewModel> ObterTodosTipoLogs();
        TipoLogViewModel ObterTipoLogId(int id);
        Object OcorrenciasTipoLog();
        void Excluir(int id);
    }
}
