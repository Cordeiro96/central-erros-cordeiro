using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class AplicacaoRepositorio : RepositorioBase<Aplicacao>, IAplicacaoRepositorio
    {
        public Aplicacao ObterAplicacaoId(int id)
        {
            IQueryable<Aplicacao> aplicacoes = _contexto.Aplicacao
                .Where(x => x.Id == id)
                .Include(x => x.Logs)
                .Include(x => x.UsuariosAplicacoes);

            aplicacoes = aplicacoes.Include(x => x.Logs).ThenInclude(up => up.TipoLog);
            aplicacoes = aplicacoes.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Usuario);

            return aplicacoes.AsNoTracking().FirstOrDefault();
        }

        public List<Aplicacao> ObterAplicacaoNome(string nome)
        {
            IQueryable<Aplicacao> aplicacoes = _contexto.Aplicacao
                .Where(x => x.Nome.Contains(nome))
                .Include(x => x.Logs)
                .Include(x => x.UsuariosAplicacoes);

            aplicacoes = aplicacoes.Include(x => x.Logs).ThenInclude(up => up.TipoLog);
            aplicacoes = aplicacoes.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Usuario);

            return aplicacoes.AsNoTracking().ToList();
        }

        public List<Aplicacao> ObterTodosAplicacoes()
        {
            IQueryable<Aplicacao> aplicacoes = _contexto.Aplicacao
                .Include(x => x.Logs)
                .Include(x => x.UsuariosAplicacoes);

            aplicacoes = aplicacoes.Include(x => x.Logs).ThenInclude(up => up.TipoLog);
            aplicacoes = aplicacoes.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Usuario);

            return aplicacoes.AsNoTracking().ToList();
        }

        public override void Alterar(Aplicacao aplicacao)
        {
            var usuApps = _contexto.UsuariosAplicacoes.Where(x => x.IdAplicacao == aplicacao.Id);
            foreach (var usuApp in usuApps)
            {
                _contexto.UsuariosAplicacoes.Remove(usuApp);
            }
            _contexto.Aplicacao.Update(aplicacao);
            _contexto.SaveChanges();
        }

        public Aplicacao ObterAplicacaoTipoLog(int app_id, int tipolog_id)
        {
            Aplicacao app = (from aplicacao in _contexto.Aplicacao where aplicacao.Id == app_id select aplicacao).FirstOrDefault();
            IQueryable<Log> querylogs = (from log in _contexto.Log where log.IdTipoLog == tipolog_id && log.IdAplicacao == app_id select log);

            List<Log> logs = querylogs.Include(x => x.TipoLog).AsNoTracking().ToList();

            app.Logs = logs;

            /*//como aplicar o where para não trazer todos os logs?
            var aplicacoes = _contexto.Aplicacao
                .Where(x => x.Id == app_id)
                .Include(x => x.Logs).ThenInclude(l => l.TipoLog);*/

            return app;
        }
    }
}
