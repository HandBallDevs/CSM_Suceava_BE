using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Property(s => s.URLPoza)
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
        }
    }
}
