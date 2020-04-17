using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class UsuarioAplicacaoAplicacao : IUsuarioAplicacaoAplicacao
    {
        private readonly IUsuarioAplicacaoRepositorio _repo;
        private readonly IMapper _mapper;

        public UsuarioAplicacaoAplicacao(IUsuarioAplicacaoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(UsuarioAplicacaoViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Domain.Modelo.UsuarioAplicacao>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(UsuarioAplicacaoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Domain.Modelo.UsuarioAplicacao>(entity));
        }

        public UsuarioAplicacaoViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<UsuarioAplicacaoViewModel>(_repo.SelecionarPorId(id));
        }

        public List<UsuarioAplicacaoViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<UsuarioAplicacaoViewModel>>(_repo.SelecionarTodos());
        }
    }
}
