using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Data.Map
{
    public class UsuariosAvisosMap : IEntityTypeConfiguration<UsuariosAvisos>
    {
        public void Configure(EntityTypeBuilder<UsuariosAvisos> builder)
        {
            builder.ToTable("UsuarioAviso");

            builder.HasKey(t => new { t.IdUsuario, t.IdAviso });

            builder.HasOne(u => u.Usuario)
                .WithMany(ua => ua.UsuariosAvisos)
                .HasForeignKey(u => u.IdUsuario);

            builder.HasOne(u => u.Aviso)
                .WithMany(ua => ua.UsuariosAvisos)
                .HasForeignKey(u => u.IdAviso);

            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
