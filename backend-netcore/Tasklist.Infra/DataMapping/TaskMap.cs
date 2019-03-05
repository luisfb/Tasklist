using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasklist.Domain.Entities;

namespace Tasklist.Infra.DataMapping
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Ignore(x => x.ValidationErrors);

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Titulo)
                .HasColumnName("titulo")
                .IsRequired();

            builder
                .Property(x => x.Descricao)
                .HasColumnName("descricao");

            builder
                .Property(x => x.Status)
                .HasColumnName("status");

            builder
                .Property(x => x.Criacao)
                .HasColumnName("criacao")
                .IsRequired();

            builder
                .Property(x => x.Alteracao)
                .HasColumnName("alteracao");

            builder
                .Property(x => x.Remocao)
                .HasColumnName("remocao");

            builder
                .Property(x => x.Conclusao)
                .HasColumnName("conclusao");
        }
    }
}
