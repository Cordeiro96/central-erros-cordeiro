using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CentralErros.Data.Repositorio
{
    public class AvisoRepositorio : RepositorioBase<Aviso>, IAvisoRepositorio
    {
        public AvisoRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public Aviso ObterAvisoId(int id)
        {
            IQueryable<Aviso> avisos = _contexto.Aviso
                .Where(x => x.Id == id)
                .Include(x => x.UsuariosAvisos);

            avisos = avisos.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Usuario);

            return avisos.AsNoTracking().FirstOrDefault();
        }

        public List<Aviso> ObterTodosAvisos(string idUsuario)
        {
            /*IQueryable<Aviso> avisos = _contexto.Aviso
                .Include(x => x.UsuariosAvisos.Where(x => x.IdUsuario == idUsuario));

            avisos = avisos.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Usuario);*/
            IQueryable<Aviso> avisos = (from aviso in _contexto.Aviso
                                        join usuaviso in _contexto.UsuariosAvisos
                                        on aviso.Id equals usuaviso.IdAviso
                                        where usuaviso.IdUsuario == idUsuario
                                        select aviso);

            avisos = avisos.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Usuario);
            var teste = avisos.AsNoTracking().ToList();
            return teste;
        }
    }
}
