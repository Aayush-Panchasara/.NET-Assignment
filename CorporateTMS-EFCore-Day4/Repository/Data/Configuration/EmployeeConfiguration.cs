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

            builder.HasData(

                    new Employee() {Id=2, Name="Mann",Email="mann.b@company.com", DepartmentId=2 },
                    
                    new Employee() {Id=4, Name="Krunal",Email="krunal.k@company.com", DepartmentId=2 },
                    new Employee() {Id=6, Name="Niken",Email="niken.p@company.com", DepartmentId=1 },
                    new Employee() {Id=7, Name="Ashish",Email="ashish.p@company.com", DepartmentId=3 },
                    new Employee() {Id=8, Name="Raj",Email="raj.r@company.com", DepartmentId=1 },
                    new Employee() {Id=9, Name="Meg",Email="Meg.m@company.com", DepartmentId=3 },
                    new Employee() {Id=10, Name="Yash",Email="yash.p@company.com", DepartmentId=5 }
                    );
        }
    }
}
