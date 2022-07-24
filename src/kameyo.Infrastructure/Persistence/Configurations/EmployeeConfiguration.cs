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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.Ignore(e => e.DomainEvents);
            builder.ToTable("Employee");

            builder.HasIndex(e => e.SubsidiaryId, "IX_Employee_SubsidiaryId");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            
            builder.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            builder.Property(e => e.CostHour)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

            builder.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.Names)
                    .HasMaxLength(250)
                    .IsUnicode(false);

            builder.Property(e => e.PhoneMobile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.PhoneOffice)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.PhoneOfficeExt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.CalculateFactor)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((1))");


            builder.HasOne(d => d.Subsidiary)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SubsidiaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Subsidiary");


        }
    }
}
