using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsExamrecordConfiguration : IEntityTypeConfiguration<EhsExamrecord>
    {
        public void Configure(EntityTypeBuilder<EhsExamrecord> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_EXAMRECORD_ID");
            builder.ToTable("EHS_EXAMRECORD");
            builder.Property(e => e.Id).UseHiLo("EXAMRECORDID").HasColumnName("ID");
            builder.Property(e => e.Answerpath).IsRequired().HasMaxLength(255).HasColumnName("ANSWERPATH");
            builder.Property(e => e.Examname).IsRequired().HasMaxLength(20).HasColumnName("EXAMNAME");
            builder.Property(e => e.Examtime).HasColumnType("DATE").HasColumnName("EXAMTIME");
            builder.Property(e => e.Lasttime).HasColumnType("INTERVAL DAY(2) TO SECOND(6)").HasColumnName("LASTTIME");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(20).HasColumnName("NAME");
            builder.Property(e => e.Objectivescore).HasColumnName("OBJECTIVESCORE");
            builder.Property(e => e.Score).HasColumnName("SCORE");
            builder.Property(e => e.Qualified).IsRequired();
            builder.Property(e => e.Status).IsRequired().HasMaxLength(20).HasColumnName("STATUS");
            builder.Property(e => e.Subjectivescore).HasColumnName("SUBJECTIVESCORE");
            builder.Property(e => e.Badge).HasColumnName("BADGE");
        }
    }
}
