using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF.ConfigurationMappings
{
    using DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.ComponentModel.DataAnnotations.Schema;

    internal class Program_Mapping : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("Program");
            builder.Property(t => t.Id).HasColumnName("Id").UseNpgsqlIdentityColumn();
            builder.Property(t => t.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
        }
    }
}
