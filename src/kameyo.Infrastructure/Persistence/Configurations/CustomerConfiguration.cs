using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("Customer");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.CostHourMen)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((1))");


            builder.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Deadlinebilling).HasDefaultValueSql("((0))");

            builder.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.NumberId)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);            

            builder.HasOne(d => d.Subsidiary)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SubsidiaryId)
                    .HasConstraintName("FK_Customer_Subsidiary");
            

        }
    }
}
