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
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Rol)
                .IsRequired();

            builder
                .Property(s => s.Nume)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(s => s.Prenume)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(s => s.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(s => s.Parola)
                .HasMaxLength(64)
                .IsRequired();

            builder
                .HasMany(s => s.Stiri)
                .WithOne(s => s.Utilizator)
                .HasForeignKey(s => s.UtilizatorId)
                .IsRequired();
        }
    }
}
