using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    [System.Obsolete]
    public class EhsQuestionConfiguration : IEntityTypeConfiguration<EhsQuestion>
    {
        [System.Obsolete]
        public void Configure(EntityTypeBuilder<EhsQuestion> entity)
        {
            entity.ToTable("EHS_QUESTION");
            entity.HasKey(e => e.Id).HasName("PK_QUESTION_ID");
            entity.Property(e => e.Id).UseHiLo("QUESTIONID").HasColumnName("ID");
            entity.Property(e => e.Answer).IsRequired().HasMaxLength(20).HasColumnName("ANSWER");
            entity.Property(e => e.Belongtolib).IsRequired().HasMaxLength(20).HasColumnName("BELONGTOLIB");
            entity.Property(e => e.Belongtosection).HasColumnName("BELONGTOSECTION").HasDefaultValueSql("0");
            entity.Property(e => e.Levels).IsRequired().HasMaxLength(20).HasColumnName("LEVELS");
            entity.Property(e => e.Optionanalysis).HasMaxLength(100).HasColumnName("OPTIONANALYSIS");
            entity.Property(e => e.Type).IsRequired().HasMaxLength(20).HasColumnName("TYPE");
        }
    }
}
