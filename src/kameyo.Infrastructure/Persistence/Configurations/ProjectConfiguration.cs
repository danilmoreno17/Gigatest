using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("Project");

            builder.HasIndex(e => e.CustomerId, "IX_Project_CustomerId");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.CloseDate).HasColumnType("date");

            builder.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.DurationHour).HasDefaultValueSql("((0))");

            builder.Property(e => e.EndDate).HasColumnType("date");

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.StartDate).HasColumnType("date");

            builder.Property(e => e.CostHourMenCustomer).HasColumnType("money");

            builder.Property(e => e.CostHourMenProject).HasColumnType("money");

            builder.HasOne(d => d.Customer)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Customer");


        }
    }
}
