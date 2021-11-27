using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EHS.DbContexts.EntityTypeConfiguration
{
    class EhsStudyrecordConfiguration : IEntityTypeConfiguration<EhsStudyrecord>
    {
        public void Configure(EntityTypeBuilder<EhsStudyrecord> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_STUDYRECORD_ID");
            builder.ToTable("EHS_STUDYRECORD");
            builder.Property(e => e.Id).HasColumnName("ID").UseHiLo("STUDYRECORDID");
            builder.Property(e => e.Courseid).IsRequired().HasColumnName("COURSE");
            builder.Property(e => e.Totalcoureseware).HasColumnName("TOTALCOURESEWARE");
            builder.Property(e => e.Updatetime).HasColumnType("DATE").HasColumnName("UPDATETIME");
            builder.Property(e => e.Badge).IsRequired().HasColumnName("USERID");
        }
    }
}
