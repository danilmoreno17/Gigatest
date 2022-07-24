using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class EmployeeAwardConfiguration : IEntityTypeConfiguration<EmployeeAward>
    {
        public void Configure(EntityTypeBuilder<EmployeeAward> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("EmployeeAward");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.HasIndex(e => e.EmployeeId, "IX_EmployeeAward_EmployeeId");

            builder.Property(e => e.Institution)
                   .HasMaxLength(250)
                   .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.AwardDate).HasColumnType("date");

            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");
            
            builder.HasOne(e => e.Employee)
                .WithMany(p => p.EmployeeAwards)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAward_Employee");
        }
    }
}
