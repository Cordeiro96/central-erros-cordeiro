using CentralErros.Application.ViewModel;
using System.Collections.Generic;

namespace CentralErros.Application.Interface
{
    public interface IUsuarioAplicacao
    {
        List<UsuarioViewModel> ObterTodosUsuarios();
        void Incluir(UsuarioViewModel entity);
        void Alterar(UsuarioViewModel entity);
        UsuarioViewModel ObterUsuarioId(int id);
        List<UsuarioViewModel> ObterUsuarioNome(string nome);
        void Excluir(int id);
    }
}
