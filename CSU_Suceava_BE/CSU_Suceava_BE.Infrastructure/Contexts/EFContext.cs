using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSU_Suceava_BE.Infrastructure.Contexts
{
    public class EFContext:DbContext
    {
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Utilizator> Utilizator { get; set; }
        public DbSet<Stire> Stire { get; set; }
        public DbSet<Meci> Meci { get; set; }
        public DbSet<IstoricPremii> IstoricPremii { get; set; }
        public DbSet<IstoricRoluri> IstoricRoluri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DBString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Staff).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Utilizator).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Stire).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IstoricPremii).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IstoricRoluri).Assembly);
        }

    }
}
