using CorporateTMS_EFCore_Day4.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTMS_EFCore_Day4.Repository.Data.Configuration
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasData(
                    new Trainer() { Id = 1, Name = "Aayush", Email = "aayush.p@company.com", ExpertiseLevel = 5, DepartmentId = 1 },
                    new Trainer() { Id = 3, Name = "Devam", Email = "devam.s@company.com", ExpertiseLevel = 4, DepartmentId = 1 },
                    new Trainer() { Id = 5, Name = "Het", Email = "het.p@company.com", ExpertiseLevel = 4, DepartmentId = 4 }
                );
        }
    }
    
    
}
