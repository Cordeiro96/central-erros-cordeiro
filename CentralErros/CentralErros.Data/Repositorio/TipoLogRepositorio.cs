using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class TipoLogRepositorio : RepositorioBase<TipoLog>, ITipoLogRepositorio
    {
        public TipoLog ObterTipoLogId(int id)
        {
            IQueryable<TipoLog> tipoLog = _contexto.TipoLog
                .Where(x => x.Id == id)
                .Include(x => x.Logs)
                .Include(x => x.Avisos);

            return tipoLog.AsNoTracking().FirstOrDefault();
        }

        public List<TipoLog> ObterTodosTipoLogs()
        {
            IQueryable<TipoLog> tipoLog = _contexto.TipoLog
                .Include(x => x.Logs)
                .Include(x => x.Avisos);

            return tipoLog.AsNoTracking().ToList();
        }

        public Object OcorrenciasTipoLog()
        {
            var query = _contexto.Log
                            .GroupBy(x => x.IdTipoLog)
                            .Select(x => new { IdTipoLog = x.Key, QtdeOcorrencia = x.Count() }).ToList();

            var dados = (from qry in query
                         join tl in _contexto.TipoLog on qry.IdTipoLog equals tl.Id
                         select new { qry.IdTipoLog, tl.Descricao, qry.QtdeOcorrencia }).ToList();

            return dados;
        }
    }
}