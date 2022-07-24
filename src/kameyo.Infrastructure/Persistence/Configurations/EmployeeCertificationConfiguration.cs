using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class EmployeeCertificationConfiguration : IEntityTypeConfiguration<EmployeeCertification>
    {
        public void Configure(EntityTypeBuilder<EmployeeCertification> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("EmployeeCertification");

            builder.HasIndex(e => e.EmployeeId, "IX_EmployeeCertification_EmployeeId");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Institution)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.EmissionDate).HasColumnType("date");
            builder.Property(e => e.ProductionDate).HasColumnType("date");
            builder.Property(e => e.ExpirationDate).HasColumnType("date");

            builder.HasOne(e => e.Employee)
                .WithMany(p => p.EmployeeCertifications)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeCertification_Employee");
        }
    }
}
