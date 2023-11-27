using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSU_Suceava_BE.Infrastructure.Contexts
{
    public class EFContext : DbContext
    {
        private readonly SecretClient secretClient;

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Utilizator> Utilizator { get; set; }
        public DbSet<Stire> Stire { get; set; }
        public DbSet<Meci> Meci { get; set; }
        public DbSet<IstoricPremii> IstoricPremii { get; set; }
        public DbSet<IstoricRoluri> IstoricRoluri { get; set; }

        public EFContext(SecretClient secretClient)
        {
            this.secretClient = secretClient;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var secret = secretClient.GetSecret(Environment.GetEnvironmentVariable("DB_SECRET"));
            string connectionString = secret.Value.Value;

            optionsBuilder.UseSqlServer(connectionString);
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
