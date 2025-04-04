using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "403d3bfc-09a0-454e-a47d-119dead04f0d", "AQAAAAIAAYagAAAAEFSd05zPh1HDHXvT6Vwxg89EbahNE+/HPOPxoFk2B2GXkymTXn/U+0hudcSxjyFiCg==", "76cf0ee8-8355-4f1b-8c54-f1d07ec2a5ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2717b251-0e1b-4c32-ae8a-11bb85ed0822", "AQAAAAIAAYagAAAAEBCjrphGuVGai2MZiJwW1+MyFLyF0rVm/7N8be3mxyEYmpEOmrVs7/qEaPrspVEaWA==", "2c3bcfc7-77e7-42f0-9150-8e50b658bfe2" });
        }
    }
}
