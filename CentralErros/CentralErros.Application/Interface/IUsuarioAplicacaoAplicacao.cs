using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IUsuarioAplicacaoAplicacao
    {
        void Incluir(UsuarioAplicacaoViewModel entity);
        void Alterar(UsuarioAplicacaoViewModel entity);
        UsuarioAplicacaoViewModel SelecionarPorId(int id);
        List<UsuarioAplicacaoViewModel> SelecionarTodos();
        void Excluir(int id);
    }
}
