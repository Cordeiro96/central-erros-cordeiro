using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class AvisoRepositorio : RepositorioBase<Aviso>, IAvisoRepositorio
    {
        public Aviso ObterAvisoId(int id)
        {
            IQueryable<Aviso> avisos = _contexto.Aviso
                .Where(x => x.Id == id)
                .Include(x => x.TipoLog)
                .Include(x => x.UsuariosAvisos);

            avisos = avisos.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Usuario);

            return avisos.AsNoTracking().FirstOrDefault();
        }

        public List<Aviso> ObterTodosAvisos()
        {
            IQueryable<Aviso> avisos = _contexto.Aviso
                .Include(x => x.TipoLog)
                .Include(x => x.UsuariosAvisos);

            avisos = avisos.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Usuario);

            return avisos.AsNoTracking().ToList();
        }
    }
}
