using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class EmployeeStudyConfiguration : IEntityTypeConfiguration<EmployeeStudy>
    {
        public void Configure(EntityTypeBuilder<EmployeeStudy> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("EmployeeStudy");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.HasIndex(e => e.EmployeeId, "IX_EmployeeStudy_EmployeeId");

            builder.Property(e => e.Institution)
                   .HasMaxLength(250)
                   .IsUnicode(false);

            builder.Property(e => e.Degree)
                   .HasMaxLength(250)
                   .IsUnicode(false);

            builder.Property(e => e.FieldKnowledge)
                   .HasMaxLength(250)
                   .IsUnicode(false);

            builder.Property(e => e.EmissionDate).HasColumnType("date");

            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.HasOne(e => e.Employee)
                .WithMany(p => p.EmployeeStudies)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeStudy_Employee");
        }
    }
}
