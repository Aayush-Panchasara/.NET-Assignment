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

            builder.Property(e => e.PerformanceScore).HasDefaultValue(0);  

            builder.ToTable(e => e.HasCheckConstraint("Enrollment_PerformanceScore", "[PerformanceScore]<=100"));


            builder.HasOne(e => e.Employee)
                   .WithMany(e => e.Enrollments)
                   .HasForeignKey(e => e.EmployeeId);

            builder.HasOne(e => e.TrainerProgram)
                   .WithMany(e => e.Enrollments)
                   .HasForeignKey(e => e.TrainerProgramId);

            builder.HasData(
                new Enrollment() { EmployeeId=2,TrainerProgramId=1,EnrollDate=new DateTime(2026,1,6), PerformanceScore=0},
                new Enrollment() { EmployeeId=2,TrainerProgramId=2,EnrollDate= new DateTime(2026, 1, 18), PerformanceScore =0},
                new Enrollment() { EmployeeId=4,TrainerProgramId=3,EnrollDate= new DateTime(2026, 1, 25) , PerformanceScore=0},
                new Enrollment() { EmployeeId=4,TrainerProgramId=1,EnrollDate= new DateTime(2026, 1, 8) , PerformanceScore=0},
                new Enrollment() { EmployeeId=3,TrainerProgramId=3,EnrollDate= new DateTime(2026, 1, 26), PerformanceScore =0},
                new Enrollment() { EmployeeId=3,TrainerProgramId=4,EnrollDate= new DateTime(2026, 2, 3) , PerformanceScore=0},
                new Enrollment() { EmployeeId=6,TrainerProgramId=1,EnrollDate= new DateTime(2026, 1, 6), PerformanceScore =0},
                new Enrollment() { EmployeeId=8,TrainerProgramId=1,EnrollDate= new DateTime(2026, 1, 7), PerformanceScore =0}
                );
        }

    }
}
