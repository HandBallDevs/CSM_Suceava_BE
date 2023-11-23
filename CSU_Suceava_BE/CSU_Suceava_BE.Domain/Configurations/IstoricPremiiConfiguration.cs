using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSU_Suceava_BE.Domain.Configurations
{
    public class IstoricPremiiConfiguration : IEntityTypeConfiguration<IstoricPremii>
    {
        public void Configure(EntityTypeBuilder<IstoricPremii> builder)
        {
            builder
                .HasKey(ip => ip.Id);

            builder
                .Property(ip => ip.NumePremiu)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(ip => ip.DataPrimire)
                .IsRequired();
        }
    }
}
