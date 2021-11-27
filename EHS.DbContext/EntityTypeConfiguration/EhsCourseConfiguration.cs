using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsCourseConfiguration : IEntityTypeConfiguration<EhsCourse>
    {
        public void Configure(EntityTypeBuilder<EhsCourse> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_COURSE_ID");
            builder.ToTable("EHS_COURSE");
            builder.Property(e => e.Id).UseHiLo("COURSEID").HasColumnName("ID");
            builder.Property(e => e.Classhour).HasColumnName("CLASSHOUR");
            builder.Property(e => e.Context).IsRequired().HasMaxLength(150).HasColumnName("CONTEXT");
            builder.Property(e => e.Coursewarefile).IsRequired().HasMaxLength(255).HasColumnName("COURSEWAREFILE");
            builder.Property(e => e.Createtime).HasColumnType("DATE").HasColumnName("CREATETIME");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(20).HasColumnName("NAME");
            builder.Property(e => e.Type).IsRequired().HasMaxLength(20).HasColumnName("TYPE");
        }
    }
}
