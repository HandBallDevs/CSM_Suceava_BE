using CSU_Suceava_BE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSU_Suceava_BE.Domain.Configurations
{
    public class StireConfiguration : IEntityTypeConfiguration<Stire>
    {
        public void Configure(EntityTypeBuilder<Stire> builder)
        {
            builder
                .HasKey(s=>s.Id);

            builder
                .Property(s => s.Titlu)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(s => s.Continut)
                .IsRequired();

            builder
                .Property(s => s.HashTaguri)
                .HasMaxLength(100)
                .IsRequired();


            builder
                .Property(s => s.DataPostare);
        }
    }
}
