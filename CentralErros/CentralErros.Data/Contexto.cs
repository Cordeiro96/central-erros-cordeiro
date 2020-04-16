using CentralErros.Data.Map;
using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Aplicacao> Aplicacao { get; set; }
        public DbSet<Aviso> Aviso { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<TipoLog> TipoLog { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioAplicacao> UsuariosAplicacoes { get; set; }
        public DbSet<UsuarioAviso> UsuariosAvisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-REEDLKL\SQLEXPRESS;Database=CentralErros;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aplicou essas configurações para que o model possa enxergar o que foi configurado nas classes MAP
            modelBuilder.ApplyConfiguration(new AplicacaoMap());
            modelBuilder.ApplyConfiguration(new AvisoMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new TipoLogMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioAplicacaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioAvisoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
