using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lesson2_17_09_25.Migrations
{
    /// <inheritdoc />
    public partial class InitStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    phoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    VkProfileLink = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Login", "MiddleName", "VkProfileLink", "phoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 9, 24, 18, 41, 43, 489, DateTimeKind.Unspecified).AddTicks(2459), new TimeSpan(0, 3, 0, 0, 0)), "vanya123@gmail.com", "Иван", "Иванов", "vanya123", "Иванович", "https://vk.com/vanya123", "+7149312931893" },
                    { 2, new DateTimeOffset(new DateTime(2025, 9, 24, 18, 41, 43, 491, DateTimeKind.Unspecified).AddTicks(7321), new TimeSpan(0, 3, 0, 0, 0)), "maria123@gmail.com", "Мария", "Иванов", "maria123", "Иванович", "https://vk.com/maria123", "+78932179832" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
