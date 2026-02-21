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
        }
    }
}
