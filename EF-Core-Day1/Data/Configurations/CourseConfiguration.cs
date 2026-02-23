using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.Data.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);
            builder.Property(c => c.Title)
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)");

            builder.HasData(
                new Course() {CourseId=1, Title="React",Fees=1500,DurationInMonths=3 },
                new Course() {CourseId=2, Title="Angular", Fees=1499,DurationInMonths=2}
                );
        }
    }
}
