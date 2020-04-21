using CentralErros.Domain.Modelo;
using CentralErros.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralErros.Data.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public List<Usuario> ObterTodosUsuarios()
        {
            IQueryable<Usuario> usuarios = _contexto.Usuario
                .Include(x => x.UsuariosAvisos)
                .Include(x => x.UsuariosAplicacoes);

            usuarios = usuarios.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Aviso);
            usuarios = usuarios.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Aplicacao);

            return usuarios.AsNoTracking().ToList();
        }

        public Usuario ObterUsuarioId(int id)
        {
            IQueryable<Usuario> usuarios = _contexto.Usuario
                .Where(x => x.Id == id)
                .Include(x => x.UsuariosAvisos)
                .Include(x => x.UsuariosAplicacoes);

            usuarios = usuarios.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Aviso);
            usuarios = usuarios.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Aplicacao);

            return usuarios.AsNoTracking().FirstOrDefault();
        }

        public List<Usuario> ObterUsuarioNome(string nome)
        {
            IQueryable<Usuario> usuarios = _contexto.Usuario
                .Where(x => x.Nome.Contains(nome))
                .Include(x => x.UsuariosAvisos)
                .Include(x => x.UsuariosAplicacoes);

            usuarios = usuarios.Include(x => x.UsuariosAvisos).ThenInclude(up => up.Aviso);
            usuarios = usuarios.Include(x => x.UsuariosAplicacoes).ThenInclude(up => up.Aplicacao);

            return usuarios.AsNoTracking().ToList();
        }

        public override void Alterar(Usuario usuario)
        {
            var usuApps = _contexto.UsuariosAplicacoes.Where(x => x.IdUsuario == usuario.Id);
            foreach (var usuApp in usuApps)
            {
                _contexto.UsuariosAplicacoes.Remove(usuApp);                
            }
            var usuAvisos = _contexto.UsuariosAvisos.Where(x => x.IdUsuario == usuario.Id);
            foreach (var usuAviso in usuAvisos)
            {
                _contexto.UsuariosAvisos.Remove(usuAviso);
            }
            _contexto.Usuario.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}