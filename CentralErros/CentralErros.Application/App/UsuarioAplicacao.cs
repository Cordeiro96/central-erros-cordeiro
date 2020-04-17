using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _repo;
        private readonly IMapper _mapper;

        public UsuarioAplicacao(IUsuarioRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(UsuarioViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Usuario>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(UsuarioViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Usuario>(entity));
        }

        public UsuarioViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<UsuarioViewModel>(_repo.SelecionarPorId(id));
        }

        public List<UsuarioViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<UsuarioViewModel>>(_repo.SelecionarTodos());
        }
    }
}
