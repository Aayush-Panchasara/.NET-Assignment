using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Data.Configuration
{
    internal class TrainingProgramConfiguration : IEntityTypeConfiguration<TrainingProgram>
    {
        public void Configure(EntityTypeBuilder<TrainingProgram> builder)
        {

            builder.Property(t => t.Title)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.HasIndex(t => t.Title).IsUnique();

            builder.HasOne(t => t.Trainer)
                   .WithMany(t => t.TrainingPrograms)
                   .HasForeignKey(t => t.TrainerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new TrainingProgram() {Id=1,Title="C# Fundamentals",Duration=2,StartDate=new DateTime(2026,1,5), TrainerId=3 },
                    new TrainingProgram() {Id=2,Title="Object Oriented Programming",Duration=1,StartDate=new DateTime(2026,1,17), TrainerId=1 },
                    new TrainingProgram() {Id=3,Title="Language Integrated Query",Duration=2,StartDate=new DateTime(2026,1,24), TrainerId=1 },
                    new TrainingProgram() {Id=4,Title="EF Core",Duration=1,StartDate=new DateTime(2026,2,2), TrainerId=5 }
                );
        }
    }
}
