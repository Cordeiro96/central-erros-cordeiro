using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class UsuarioAvisoAplicacao : IUsuarioAvisoAplicacao
    {
        private readonly IUsuarioAvisoRepositorio _repo;
        private readonly IMapper _mapper;

        public UsuarioAvisoAplicacao(IUsuarioAvisoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(UsuarioAvisoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<UsuarioAviso>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(UsuarioAvisoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<UsuarioAviso>(entity));
        }

        public UsuarioAvisoViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<UsuarioAvisoViewModel>(_repo.SelecionarPorId(id));
        }

        public List<UsuarioAvisoViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<UsuarioAvisoViewModel>>(_repo.SelecionarTodos());
        }
    }
}
