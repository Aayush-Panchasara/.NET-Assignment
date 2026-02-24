using EF_Core_Day1.Data.Configurations;
using EF_Core_Day1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Day1.Data
{
    internal class AppContextDB : DbContext
    {
        int queryCount = 0;
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Batch> Batches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-3GIF0DSB\\SQLEXPRESS;Database= EFCoreDB; Trusted_Connection=True; TrustServerCertificate=True")
                .UseLazyLoadingProxies()
                .LogTo(message =>
                {
                    if(message.Contains("Executed DbCommand"))
                    {
                        queryCount++;
                        Console.WriteLine($"\nQuery {queryCount}");
                        //Console.WriteLine(message);
                    }
                })
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new TrainerConfiguration());
        }
    }
}
