using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsCoursewareConfiguration : IEntityTypeConfiguration<EhsCourseware>
    {
        public void Configure(EntityTypeBuilder<EhsCourseware> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_COURSEWARE_ID");
            builder.ToTable("EHS_COURSEWARE");
            builder.Property(e => e.Id).UseHiLo("COURSEWAREID").HasColumnName("ID");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnName("NAME");
            builder.Property(e => e.Starttime).IsRequired().HasColumnType("DATE").HasColumnName("STARTTIME");
            builder.Property(e => e.Extension).IsRequired().HasMaxLength(20).HasColumnName("EXTENSION");
            builder.Property(e => e.Capable).IsRequired().HasColumnName("CAPABLE");
            builder.Property(e => e.Tag).HasMaxLength(20).HasColumnName("TAG");
            builder.Property(e => e.Type).IsRequired().HasMaxLength(20).HasColumnName("TYPE");
        }
    }
}
