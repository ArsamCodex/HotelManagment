using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f484dbd2-62e1-4b6b-a2de-eb41c9b363ee", "d80d2bd4-6b34-44fc-b97d-adfe96741f18" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f484dbd2-62e1-4b6b-a2de-eb41c9b363ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d80d2bd4-6b34-44fc-b97d-adfe96741f18");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46cbe2c5-bd99-4b2a-903e-3dc0c0b24b43", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75b71b12-7177-4733-8f21-c798d179b82f", 0, "d07f235c-8ade-4a15-8715-c4799db660db", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "37cc32fa-440c-48c7-ba1c-a407140e589e", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46cbe2c5-bd99-4b2a-903e-3dc0c0b24b43", "75b71b12-7177-4733-8f21-c798d179b82f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46cbe2c5-bd99-4b2a-903e-3dc0c0b24b43", "75b71b12-7177-4733-8f21-c798d179b82f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46cbe2c5-bd99-4b2a-903e-3dc0c0b24b43");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75b71b12-7177-4733-8f21-c798d179b82f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f484dbd2-62e1-4b6b-a2de-eb41c9b363ee", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d80d2bd4-6b34-44fc-b97d-adfe96741f18", 0, "0f17a56e-bf28-4027-b15f-15a88c70b4c9", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "c7d86519-0e98-4b32-b0c9-65fd24f5d3c7", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f484dbd2-62e1-4b6b-a2de-eb41c9b363ee", "d80d2bd4-6b34-44fc-b97d-adfe96741f18" });
        }
    }
}
