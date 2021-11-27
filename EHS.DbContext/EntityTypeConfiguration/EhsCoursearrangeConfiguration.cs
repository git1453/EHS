using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsCoursearrangeConfiguration : IEntityTypeConfiguration<EhsCoursearrange>
    {
        public void Configure(EntityTypeBuilder<EhsCoursearrange> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_COURSEARRANGE_ID");
            builder.ToTable("EHS_COURSEARRANGE");
            builder.Property(e => e.Id).HasColumnName("ID").UseHiLo("COURSEARRANGEID");
            builder.Property(e => e.Courseid).HasColumnName("COURSEID");
            builder.Property(e => e.Badge).HasColumnName("BADGE");
            builder.Property(e => e.Authority).HasColumnName("AUTHORITY");
        }
    }
}
