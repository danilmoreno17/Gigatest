using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class EmployeeExperienceConfigurationn : IEntityTypeConfiguration<EmployeeExperience>
    {
        public void Configure(EntityTypeBuilder<EmployeeExperience> builder)
        {
            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("EmployeeExperience");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.HasIndex(e => e.EmployeeId, "IX_EmployeeExperience_EmployeeId");

            builder.Property(e => e.Title)
                            .HasMaxLength(250)
                            .IsUnicode(false);

            builder.Property(e => e.CompanyName)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Type)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.CompanyCity)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.BeginDate).HasColumnType("date");

            builder.Property(e => e.FinishDate).HasColumnType("date");
            
            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.HasOne(e => e.Employee)
                .WithMany(p => p.EmployeeExperiences)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeExperience_Employee");
        }
    }
}
