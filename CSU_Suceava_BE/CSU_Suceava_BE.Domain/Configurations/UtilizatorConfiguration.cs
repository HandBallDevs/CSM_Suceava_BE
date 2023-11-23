using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSU_Suceava_BE.Domain.Configurations
{
    public class UtilizatorConfiguration : IEntityTypeConfiguration<Utilizator>
    {
        public void Configure(EntityTypeBuilder<Utilizator> builder)
        {
            builder
                .HasKey(ip => ip.Id);

            builder
                .Property(ip => ip.Rol)
                .IsRequired();

            builder
                .Property(ip => ip.Nume)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(ip => ip.Prenume)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(ip => ip.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(ip => ip.Parola)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
