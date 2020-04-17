using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class LogAplicacao : ILogAplicacao
    {
        private readonly ILogRepositorio _repo;
        private readonly IMapper _mapper;

        public LogAplicacao(ILogRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(LogViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Log>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(LogViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Log>(entity));
        }

        public LogViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<LogViewModel>(_repo.SelecionarPorId(id));
        }

        public List<LogViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<LogViewModel>>(_repo.SelecionarTodos());
        }
    }
}
