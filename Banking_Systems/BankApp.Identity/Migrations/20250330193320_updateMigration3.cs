using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97c59f67-61e1-4276-8dac-3d760395775a", "AQAAAAIAAYagAAAAEKT6KWQpkp04XeXl9QwwJaFq7YezsajU+n7O0RAZvTjw5dYkPbR+gGLFhs2NqVzflw==", "a9afa2cc-0f36-40ef-9a01-da1e171f047a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08e0398a-6944-4317-96de-ee5cabf2225a", "AQAAAAIAAYagAAAAEKG/0VyTsxQVEDyhkFVxz9Mvrl7X8euR2JNarUqfKCMn84S1H33NF5V/vLMzuQRMKA==", "afce4a9f-ec8d-479d-a724-eef43d5a824c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b35084a-1275-43ab-b66d-29295f4fc626", "AQAAAAIAAYagAAAAEBqipql+Ftp3j1EjhcYSaxVMWI1Rc3ZUhSZYVOvzHJ8vn2ORvpIVrNfT0TpI8iZWXg==", "95511cc4-c3b3-4732-be44-4595bfe0baf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f518f124-dd06-4e51-ac8d-e995d6b79662", "AQAAAAIAAYagAAAAELhek2FuKmrwrSMk1gAIhisQjdZe/KeIgsnJpCf02lRV9FkNUOLQpbqhKNl0EGLWOg==", "af4f2837-069d-429f-9d64-023bf4578846" });
        }
    }
}
