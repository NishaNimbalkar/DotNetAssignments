using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba48e6a5-797b-49ae-9de7-40fa7ff3d0d6", "AQAAAAIAAYagAAAAEFU99JsQTLXitlYmWoe/XV7xUa5gxnmxAeyaEAw0R3CUnzO3nB3Kk9luGecDMoVU7A==", "d100cd7f-4363-4a46-ac00-f59400db15d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d78ff51-1266-42b2-929a-c0e05887c8c2", "AQAAAAIAAYagAAAAEPqhbo3vxim667s2rspE5Zu9yhPcmWZ1Ighh1DmW8MSAr1ZESoveQDaPw29rAnOfzA==", "4e39b865-e2cd-4187-a75b-80121358a345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
