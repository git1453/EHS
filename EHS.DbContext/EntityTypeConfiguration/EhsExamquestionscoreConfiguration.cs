using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsExamquestionscoreConfiguration : IEntityTypeConfiguration<EhsExamquestionscore>
    {
        public void Configure(EntityTypeBuilder<EhsExamquestionscore> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_EXAMQUESTIONSCORE_ID");
            builder.ToTable("EHS_EXAMQUESTIONSCORE");
            builder.Property(e => e.Examname).IsRequired().HasMaxLength(30).HasColumnName("EXAMNAME");
            builder.Property(e => e.Id).UseHiLo("EXAMQUESTIONSCOREID").HasColumnName("ID");
            builder.Property(e => e.Questionid).HasColumnName("QUESTIONID");
            builder.Property(e => e.Questionscore).HasColumnName("QUESTIONSCORE");
        }
    }
}
