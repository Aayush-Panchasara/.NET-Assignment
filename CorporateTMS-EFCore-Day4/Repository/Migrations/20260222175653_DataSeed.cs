using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CorporateTMS_EFCore_Day4.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmedabad", "IT" },
                    { 2, "Mumbai", "HR" },
                    { 3, "Chennai", "Sales" },
                    { 4, "Delhi", "Marketing" },
                    { 5, "Banglore", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "EmployeeType", "ExpertiseLevel", "Name" },
                values: new object[] { 1, 1, "aayush.p@company.com", "Trainer", 5, "Aayush" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "EmployeeType", "Name" },
                values: new object[] { 2, 2, "mann.b@company.com", "Emplpyee", "Mann" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "EmployeeType", "ExpertiseLevel", "Name" },
                values: new object[] { 3, 1, "devam.s@company.com", "Trainer", 4, "Devam" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "EmployeeType", "Name" },
                values: new object[] { 4, 2, "krunal.k@company.com", "Emplpyee", "Krunal" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "EmployeeType", "ExpertiseLevel", "Name" },
                values: new object[] { 5, 4, "het.p@company.com", "Trainer", 4, "Het" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "EmployeeType", "Name" },
                values: new object[,]
                {
                    { 6, 1, "niken.p@company.com", "Emplpyee", "Niken" },
                    { 7, 3, "ashish.p@company.com", "Emplpyee", "Ashish" },
                    { 8, 1, "raj.r@company.com", "Emplpyee", "Raj" },
                    { 9, 3, "Meg.m@company.com", "Emplpyee", "Meg" },
                    { 10, 5, "yash.p@company.com", "Emplpyee", "Yash" }
                });

            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "Id", "Duration", "StartDate", "Title", "TrainerId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Fundamentals", 3 },
                    { 2, 1, new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Object Oriented Programming", 1 },
                    { 3, 2, new DateTime(2026, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Language Integrated Query", 1 },
                    { 4, 1, new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "EF Core", 5 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EmployeeId", "TrainerProgramId", "EnrollDate", "PerformanceScore" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, 2, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, 3, new DateTime(2026, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, 4, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 4, 1, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 4, 3, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 6, 1, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 8, 1, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "EmployeeId", "TrainerProgramId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
