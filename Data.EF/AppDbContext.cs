﻿using Data.EF.ConfigurationMappings;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;

namespace Data.EF
{
    public class AppDbContext : DbContext
    {
        private string GetConnectionString()
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            return builder.ToString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = GetConnectionString();
            optionsBuilder.UseNpgsql(connstr);
        //     => optionsBuilder.UseNpgsql("Host=ec2-54-221-201-212.compute-1.amazonaws.com; Database=de6gvrm4dkirq0;Username=jlujkukjbtling;Password=9ba6885067c78d2ced380d7bb2acf21723fc65e7c2a20e1cbe558b1a9c80223b; sslmode=Require; Trust Server Certificate=true");
            //      => optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));
            //              => optionsBuilder.UseNpgsql("Host=localhost; Database=lisasm-webapp1;Username=postgres;Password=");
        }

        public DbSet<DomainModel.Program> Programs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.ApplyConfiguration<Program>(new Program_Mapping());

        }
    }
}
