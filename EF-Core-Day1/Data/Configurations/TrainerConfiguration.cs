using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.Data.Configurations
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar(50)");

            builder.Property(t => t.ExperienceInYear)
                   .IsRequired();

            builder.HasData(
                new Trainer() {Id=1, Name="JayDip", ExperienceInYear=4 },
                new Trainer() {Id=2, Name="Vivek", ExperienceInYear=3 }
                );
        }
    }
}
