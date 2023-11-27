using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSU_Suceava_BE.Domain.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Nume)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(s => s.Prenume)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(s => s.Nationalitate)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(s => s.TipLot)
                .HasPrecision(1)
                .IsRequired();

            builder
                .Property(s => s.Post)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(s => s.Poza)
                .HasMaxLength(2000)
                .IsRequired();

            builder
                .Property(s => s.DataNastere)
                .IsRequired();

            builder
                .Property(s => s.Inaltime)
                .HasPrecision(3, 2)
                .IsRequired();

            builder
                .Property(s => s.Descriere)
                .HasMaxLength(5000);

            builder
                .HasMany(s => s.IstoricPremii)
                .WithOne(ip => ip.Staff)
                .HasForeignKey(ip => ip.StaffId)
                 .IsRequired();

            builder
                .HasMany(s => s.IstoricRoluri)
                .WithOne(ir => ir.Staff)
                .HasForeignKey(ir => ir.StaffId)
                .IsRequired();
        }
    }
}
