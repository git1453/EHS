using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    public class EhsLibConfiguration : IEntityTypeConfiguration<EhsLib>
    {
        public void Configure(EntityTypeBuilder<EhsLib> builder)
        {
            builder.HasKey(e => e.Libname)
                   .HasName("PK_LIB_LIBNAME");

            builder.ToTable("EHS_LIB");

            builder.Property(e => e.Libname)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("LIBNAME");

            builder.Property(e => e.Createtime)
                .HasColumnType("DATE")
                .HasColumnName("CREATETIME");

            builder.Property(e => e.Libsummary)
                .HasMaxLength(200)
                .HasColumnName("LIBSUMMARY");

            builder.Property(e => e.Questcount)
                .HasColumnName("QUESTCOUNT");

            builder.Property(e => e.Sectioncount)
                .HasColumnName("SECTIONCOUNT");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("TYPE");

            builder.Property(e => e.Usage)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("USAGE");
        }
    }
}
