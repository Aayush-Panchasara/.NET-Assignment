using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.Data.Configurations
{
    internal class StudentConfiguration: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student() {Id=-1, Name="Niken Patel",Email="niken.p@student.com",CreatedDate=DateOnly.FromDateTime(DateTime.Now) },
                new Student() {Id=-2, Name="Devam Satasiya",Email="devam.s@student.com",CreatedDate=DateOnly.FromDateTime(DateTime.Now) },
                new Student() {Id=-3, Name="Mann Badreshiya",Email="mann.b@student.com",CreatedDate=DateOnly.FromDateTime(DateTime.Now) }
                );
        }
    }
}
