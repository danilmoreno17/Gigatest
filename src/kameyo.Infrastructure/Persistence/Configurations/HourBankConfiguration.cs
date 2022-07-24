using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class HourBankConfiguration : IEntityTypeConfiguration<HourBank>
    {
        public void Configure(EntityTypeBuilder<HourBank> builder)
        {

            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("HourBank");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.DateValidity).HasColumnType("date");

            builder.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.HourCost)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

            builder.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.PurchaseOrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Terms)
                    .HasMaxLength(500)
                    .IsUnicode(false);

            builder.HasOne(d => d.Customer)
                    .WithMany(p => p.HourBanks)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_HourBank_Customer");
            

        }
    }
}
