using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c7ac4d5-1e65-47b5-90cb-fd2cdee69a6f", "AQAAAAIAAYagAAAAEC+1dzCg9azvbFFY7Q6IF4y/PWB7i6Cf5E2F/qqphLncxagJqN5IasURUY+rEU2m+w==", "19ec5588-035f-4f48-a34c-ce1d1f06fb10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbc54c9d-97b0-44eb-b59d-ad5cc6f70665", "AQAAAAIAAYagAAAAECvSMaUhlx5ARNk3D0JItfySW+BnkUgyEy3km+O/D3hWd1mr0YmFIDvMw69mLO7yVw==", "4a2bdfd1-06b1-4605-8620-c514f7787332" });
        }
    }
}
