using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Data.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.HasIndex(e => e.Email)
                   .IsUnique();

            builder.Property(e => e.Email)
                    .IsRequired();

            builder.HasOne(e => e.Department)
                    .WithMany(e => e.Employees)
                    .HasForeignKey(e => e.DepartmentId);

            builder.HasDiscriminator<string>("EmployeeType")
                    .HasValue<Employee>("Emplpyee")
                    .HasValue<Trainer>("Trainer");
        }
    }
}
