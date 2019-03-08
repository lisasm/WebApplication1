using Data.EF.ConfigurationMappings;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.EF
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));
 //         => optionsBuilder.UseNpgsql("Host=localhost; Database=lisasm-webapp1;Username=postgres;Password=");

        public DbSet<DomainModel.Program> Programs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.ApplyConfiguration<Program>(new Program_Mapping());

        }
    }
}
