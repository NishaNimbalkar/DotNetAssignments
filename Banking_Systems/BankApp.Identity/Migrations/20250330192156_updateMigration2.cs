using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dda13ebc-fe21-43c0-8d19-58ec756942ff", "AQAAAAIAAYagAAAAEKGHe294Tg5q+nugdjsJS7YncbYCEvCV/ZeFDKUT8ND0Caxxj10vxlzCE8cFCgDimA==", "11bdac75-761c-4c9b-8ecf-7e1fef26283e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce5bba95-2337-4fcb-ad08-5b417c843647", "AQAAAAIAAYagAAAAEAjrJ6o+ZYJsAIzsLWsjuz/xhtE7ewjJASj6F8IbBEGSlXyop7VF2dHkxrkwC24fCw==", "1c2865c0-d757-44ce-9a71-79d8c0d32363" });
        }
    }
}
