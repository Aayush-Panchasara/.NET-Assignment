using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Data.Configuration
{
    internal class DepartmentConfiguration :IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.Property(d => d.Location)
                    .IsRequired()
                    .HasColumnType("varchar(70)");

            builder.HasData(
                    new Department() { Id = 1, Name = "IT", Location = "Ahmedabad" },
                    new Department() { Id = 2, Name = "HR", Location = "Mumbai" },
                    new Department() { Id = 3, Name = "Sales", Location = "Chennai" },
                    new Department() { Id = 4, Name = "Marketing", Location = "Delhi" },
                    new Department() { Id = 5, Name = "Finance", Location = "Banglore" }
                    );
                    

        }
    }
}
