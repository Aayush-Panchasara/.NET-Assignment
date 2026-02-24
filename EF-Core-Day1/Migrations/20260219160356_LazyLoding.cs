using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Day1.Migrations
{
    /// <inheritdoc />
    public partial class LazyLoding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 19));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 19));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 19));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 18));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 18));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 18));
        }
    }
}
