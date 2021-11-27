using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHS.DbContexts.EntityTypeConfiguration
{
    [System.Obsolete]
    public class EhsOccupationalhazardConfiguration : IEntityTypeConfiguration<EhsOccupationalhazard>
    {
        [System.Obsolete]
        public void Configure(EntityTypeBuilder<EhsOccupationalhazard> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_OCCUPATIONALHAZARD_ID");
            builder.ToTable("EHS_OCCUPATIONALHAZARD");

            builder.Property(e => e.Id).UseHiLo("OCCUPATTIONALHAZARDID")
                //.HasPrecision(9)
                .HasColumnName("ID");

            builder.Property(e => e.Businessdivision)
                .IsRequired()
                .HasMaxLength(20)

                .HasColumnName("BUSINESSDIVISION");

            builder.Property(e => e.Contraindications)
                .IsRequired()
                .HasMaxLength(200)

                .HasColumnName("CONTRAINDICATIONS");

            builder.Property(e => e.Department)
                .IsRequired()
                .HasMaxLength(20)

                .HasColumnName("DEPARTMENT");

            builder.Property(e => e.Factor)
                .IsRequired()
                .HasMaxLength(200)

                .HasColumnName("FACTOR");

            builder.Property(e => e.Harm)
                .IsRequired()
                .HasMaxLength(200)

                .HasColumnName("HARM");

            builder.Property(e => e.Postion)
                .IsRequired()
                .HasMaxLength(20)

                .HasColumnName("POSTION");

            builder.Property(e => e.Protect)
                .IsRequired()
                .HasMaxLength(200)

                .HasColumnName("PROTECT");
        }
    }
}
