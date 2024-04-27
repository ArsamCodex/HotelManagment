using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMessdddageClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "sendMessage",
                columns: table => new
                {
                    SendMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sendMessage", x => x.SendMessageID);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sendMessage");

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
    }
}
