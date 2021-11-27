using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsCoursefolderConfiguration : IEntityTypeConfiguration<EhsCoursefolder>
    {
        public void Configure(EntityTypeBuilder<EhsCoursefolder> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_COURSEFOLDER_ID");
            builder.ToTable("EHS_COURSEFOLDER");
            builder.Property(e => e.Id).UseHiLo("COURSEFOLDERID").HasColumnName("ID");
            builder.Property(e => e.Courseid).HasColumnName("COURSEID");
            builder.Property(e => e.Foldername).HasMaxLength(20).HasColumnName("FOLDERNAME");
        }
    }
}
