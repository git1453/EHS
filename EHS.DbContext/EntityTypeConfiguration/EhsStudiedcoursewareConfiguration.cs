using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsStudiedcoursewareConfiguration : IEntityTypeConfiguration<EhsStudiedcourseware>
    {
        public void Configure(EntityTypeBuilder<EhsStudiedcourseware> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_STUDIEDCOURSEWARE_ID");
            builder.ToTable("EHS_STUDIEDCOURSEWARE");
            builder.Property(e => e.Id).HasColumnName("ID").UseHiLo("STUDYRECORDID");
            builder.Property(e => e.Badge).IsRequired().HasColumnName("USERID");
            builder.Property(e => e.Courseid).IsRequired().HasColumnName("COURSEID");
            builder.Property(e => e.Coursewareid).IsRequired().HasColumnName("COURSEWAREID");
        }
    }
}
