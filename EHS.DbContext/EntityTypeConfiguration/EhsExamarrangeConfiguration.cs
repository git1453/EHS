using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    class EhsExamarrangeConfiguration : IEntityTypeConfiguration<EhsExamarrange>
    {
        public void Configure(EntityTypeBuilder<EhsExamarrange> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_EXAMARRANGE_ID");
            builder.ToTable("EHS_EXAMARRANGE");
            builder.Property(e => e.Id).UseHiLo("EXAMARRANGEID").HasColumnName("ID");
            builder.Property(e => e.Authority).IsRequired().HasMaxLength(20).HasColumnName("AUTHORITY");
            builder.Property(e => e.Badge).HasColumnName("BADGE");
            builder.Property(e => e.Department).HasMaxLength(20).HasColumnName("DEPARTMENT");
            builder.Property(e => e.Examname).IsRequired().HasMaxLength(20).HasColumnName("EXAMNAME");
            builder.Property(e => e.Password).HasMaxLength(20).HasColumnName("PASSWORD");
        }
    }
}
