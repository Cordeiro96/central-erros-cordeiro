using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Domain.Repositorio
{
    public interface IRepositorioBase<T> : IDisposable where T : class, IEntity
    {
        void Incluir(T entity);

        void Alterar(T entity);

        T SelecionarPorId(int id);

        List<T> SelecionarTodos();

        void Excluir(int id);
    }
}
