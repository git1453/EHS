using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsExamConfiguration : IEntityTypeConfiguration<EhsExam>
    {
        public void Configure(EntityTypeBuilder<EhsExam> builder)
        {
            builder.HasKey(e => e.Examname).HasName("PK_EXAM_EXNAME");
            builder.ToTable("EHS_EXAM");
            builder.Property(e => e.Anhuan).IsRequired().HasColumnName("ANHUAN").HasDefaultValueSql("0 ");
            builder.Property(e => e.Examname).HasMaxLength(30).HasColumnName("EXAMNAME");
            builder.Property(e => e.Artifitial).IsRequired().HasColumnName("ARTIFITIAL").HasDefaultValueSql("0 ");
            builder.Property(e => e.Endtime).HasColumnType("DATE").HasColumnName("ENDTIME");
            builder.Property(e => e.Examfile).IsRequired().HasMaxLength(255).HasColumnName("EXAMFILE");
            builder.Property(e => e.Levels).IsRequired().HasMaxLength(20).HasColumnName("LEVELS");
            builder.Property(e => e.Libname).IsRequired().HasMaxLength(20).HasColumnName("LIBNAME");
            builder.Property(e => e.Limitcount).HasColumnName("LIMITCOUNT");
            builder.Property(e => e.Limittime).IsRequired().HasColumnName("LIMITTIME").HasDefaultValueSql("0 ");
            builder.Property(e => e.Lsattime).HasColumnType("INTERVAL DAY(2) TO SECOND(6)").HasColumnName("LSATTIME");
            builder.Property(e => e.Qualifiedscore).HasColumnName("QUALIFIEDSCORE");
            builder.Property(e => e.Section).HasColumnName("SECTION").HasDefaultValueSql("0");
            builder.Property(e => e.Starttime).HasColumnType("DATE").HasColumnName("STARTTIME");
            builder.Property(e => e.Toalscore).HasColumnName("TOALSCORE");
            builder.Property(e => e.Type).IsRequired().HasMaxLength(20).HasColumnName("TYPE");
        }
    }
}
