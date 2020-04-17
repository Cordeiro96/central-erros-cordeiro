using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IUsuarioAvisoAplicacao
    {
        void Incluir(UsuarioAvisoViewModel entity);
        void Alterar(UsuarioAvisoViewModel entity);
        UsuarioAvisoViewModel SelecionarPorId(int id);
        List<UsuarioAvisoViewModel> SelecionarTodos();
        void Excluir(int id);
    }
}
