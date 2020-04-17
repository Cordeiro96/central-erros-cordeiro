using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class AplicacaoAplicacao : IAplicacaoAplicacao
    {
        private readonly IAplicacaoRepositorio _repo;
        private readonly IMapper _mapper;

        public AplicacaoAplicacao(IAplicacaoRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(AplicacaoViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Aplicacao>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(AplicacaoViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Aplicacao>(entity));
        }

        public AplicacaoViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<AplicacaoViewModel>(_repo.SelecionarPorId(id));
        }

        public List<AplicacaoViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<AplicacaoViewModel>>(_repo.SelecionarTodos());
        }
    }
}
