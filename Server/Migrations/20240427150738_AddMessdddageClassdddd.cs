using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMessdddageClassdddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aac4c6a0-5a75-4261-8982-2b6038b32ff2", "708302f9-3d59-4493-970a-d5c6aa2eb28c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac4c6a0-5a75-4261-8982-2b6038b32ff2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "708302f9-3d59-4493-970a-d5c6aa2eb28c");

            migrationBuilder.AddColumn<string>(
                name: "MessageTitle",
                table: "sendMessage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44a2e8cf-fc94-4403-9a97-75f1872041f6", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a74f992e-0293-4ec3-9b18-d9368cf1db73", 0, "c48a3c01-edb5-4288-a543-e720163525d7", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "c23ce7ae-89f6-4e8c-9723-408dea40c55d", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "44a2e8cf-fc94-4403-9a97-75f1872041f6", "a74f992e-0293-4ec3-9b18-d9368cf1db73" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "44a2e8cf-fc94-4403-9a97-75f1872041f6", "a74f992e-0293-4ec3-9b18-d9368cf1db73" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a2e8cf-fc94-4403-9a97-75f1872041f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a74f992e-0293-4ec3-9b18-d9368cf1db73");

            migrationBuilder.DropColumn(
                name: "MessageTitle",
                table: "sendMessage");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aac4c6a0-5a75-4261-8982-2b6038b32ff2", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "708302f9-3d59-4493-970a-d5c6aa2eb28c", 0, "500b1961-8df1-4f87-87aa-5ddc0e0b74aa", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "afe38007-f894-4999-befd-6aa3a2a3bf46", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aac4c6a0-5a75-4261-8982-2b6038b32ff2", "708302f9-3d59-4493-970a-d5c6aa2eb28c" });
        }
    }
}
