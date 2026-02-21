using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Data.Configuration
{
    internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder) {

            builder.HasKey(e => new { e.EmployeeId, e.TrainerProgramId });

            builder.ToTable(e => e.HasCheckConstraint("Enrollment_PerformanceScore", "[PerformanceScore]<=100"));

            builder.HasOne(e => e.Employee)
                   .WithMany(e => e.Enrollments)
                   .HasForeignKey(e => e.EmployeeId);

            builder.HasOne(e => e.TrainerProgram)
                   .WithMany(e => e.Enrollments)
                   .HasForeignKey(e => e.TrainerProgramId);
        }

    }
}
