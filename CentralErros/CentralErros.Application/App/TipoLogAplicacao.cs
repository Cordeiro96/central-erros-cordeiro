using AutoMapper;
using CentralErros.Application.Interface;
using CentralErros.Application.ViewModel;
using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using System;
using System.Collections.Generic;

namespace CentralErros.Application.App
{
    public class TipoLogAplicacao : ITipoLogAplicacao
    {
        private readonly ITipoLogRepositorio _repo;
        private readonly IMapper _mapper;

        public TipoLogAplicacao(ITipoLogRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Alterar(TipoLogViewModel entity)
        {
            _repo.Alterar(_mapper.Map<TipoLog>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(TipoLogViewModel entity)
        {
            _repo.Incluir(_mapper.Map<TipoLog>(entity));
        }

        public TipoLogViewModel ObterTipoLogId(int id)
        {
            return _mapper.Map<TipoLogViewModel>(_repo.ObterTipoLogId(id));
        }

        public List<TipoLogViewModel> ObterTodosTipoLogs()
        {
            return _mapper.Map<List<TipoLogViewModel>>(_repo.ObterTodosTipoLogs());
        }

        public Object OcorrenciasTipoLog()
        {
            return _repo.OcorrenciasTipoLog();
        }
    }
}
