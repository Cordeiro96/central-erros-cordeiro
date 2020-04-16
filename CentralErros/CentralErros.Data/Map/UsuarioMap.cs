using CentralErros.Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErros.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Nivel)
                .HasColumnType("smallint")
                .IsRequired();
        }
    }
}
