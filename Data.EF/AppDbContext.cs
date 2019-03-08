using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.EF
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));
//          => optionsBuilder.UseNpgsql("Host=localhost; Database=lisasm-webapp1;Username=postgres;Password=");

        public DbSet<DomainModel.Program> Programs { get; set; }
    }
}
