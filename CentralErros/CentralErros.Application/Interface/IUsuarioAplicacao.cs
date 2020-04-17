using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IUsuarioAplicacao
    {
        void Incluir(UsuarioViewModel entity);
        void Alterar(UsuarioViewModel entity);
        UsuarioViewModel SelecionarPorId(int id);
        List<UsuarioViewModel> SelecionarTodos();
        void Excluir(int id);
    }
}
