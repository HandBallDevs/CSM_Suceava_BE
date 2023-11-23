using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSU_Suceava_BE.Domain.Configurations
{
    public class IstoricRoluriConfiguration : IEntityTypeConfiguration<IstoricRoluri>
    {
        public void Configure(EntityTypeBuilder<IstoricRoluri> builder)
        {
            builder
                .HasKey(ir => ir.Id);

            builder
                .Property(ir => ir.NumeRol)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(ir => ir.DataIncepere)
                .IsRequired();

            builder
                .Property(ir => ir.DataFinalizare)
                .IsRequired();
        }
    }
}
