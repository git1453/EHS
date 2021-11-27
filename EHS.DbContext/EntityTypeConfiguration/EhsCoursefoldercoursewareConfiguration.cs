using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsCoursefoldercoursewareConfiguration : IEntityTypeConfiguration<EhsCoursefoldercourseware>
    {
        public void Configure(EntityTypeBuilder<EhsCoursefoldercourseware> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_COURSEFOLDERCOURSEWARE_ID");
            builder.HasIndex(e => e.Courseid).HasDatabaseName("CFCW_COURSEID_IDX");
            builder.ToTable("EHS_COURSEFOLDERCOURSEWARE");
            builder.Property(e => e.Id).UseHiLo("COURSEFOLDERCOURSEWAREID").HasColumnName("ID");
            builder.Property(e => e.Courseid).HasColumnName("COURSEID");
            builder.Property(e => e.Foldeid).HasColumnName("FOLDERID");
            builder.Property(e => e.Courseware).HasColumnName("COURSEWARE");
        }
    }
}
