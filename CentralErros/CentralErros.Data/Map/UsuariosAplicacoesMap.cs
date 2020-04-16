using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Data.Map
{
    public class UsuariosAplicacoesMap : IEntityTypeConfiguration<UsuariosAplicacoes>
    {
        public void Configure(EntityTypeBuilder<UsuariosAplicacoes> builder)
        {
            builder.ToTable("UsuarioAplicacao");

            builder.HasKey(t => new { t.IdUsuario, t.IdAplicacao });

            builder.HasOne(u => u.Usuario)
                .WithMany(ua => ua.UsuariosAplicacoes)
                .HasForeignKey(u => u.IdUsuario);

            builder.HasOne(u => u.Aplicacao)
                .WithMany(ua => ua.UsuariosAplicacoes)
                .HasForeignKey(u => u.IdAplicacao);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
