using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class Post23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ccbe0b1a-5200-45bd-919d-48294b36ff75", "0633e466-21ba-4e0f-9a20-f1d096ff53e9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccbe0b1a-5200-45bd-919d-48294b36ff75");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0633e466-21ba-4e0f-9a20-f1d096ff53e9");

            migrationBuilder.CreateTable(
                name: "reception",
                columns: table => new
                {
                    ReceptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception", x => x.ReceptionId);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForWhichRoom = table.Column<int>(type: "int", nullable: false),
                    ReceptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_post_reception_ReceptionId",
                        column: x => x.ReceptionId,
                        principalTable: "reception",
                        principalColumn: "ReceptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "badcd42b-2d07-4726-ad75-e0bcb96fb8e2", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "89b277dc-11db-46a3-ac35-1163d7b3fff8", 0, "9ce5daac-cba1-4a9a-917e-bac1910950c0", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "fd616b02-a6b9-43a0-82a4-9d1e0c2df4a6", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "badcd42b-2d07-4726-ad75-e0bcb96fb8e2", "89b277dc-11db-46a3-ac35-1163d7b3fff8" });

            migrationBuilder.CreateIndex(
                name: "IX_post_ReceptionId",
                table: "post",
                column: "ReceptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "reception");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "badcd42b-2d07-4726-ad75-e0bcb96fb8e2", "89b277dc-11db-46a3-ac35-1163d7b3fff8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "badcd42b-2d07-4726-ad75-e0bcb96fb8e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89b277dc-11db-46a3-ac35-1163d7b3fff8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccbe0b1a-5200-45bd-919d-48294b36ff75", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0633e466-21ba-4e0f-9a20-f1d096ff53e9", 0, "f95f92c0-5795-43c3-a8e7-44079c5505c7", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "cd6cdf75-32b9-4ad4-a5bd-70f8a03560f3", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ccbe0b1a-5200-45bd-919d-48294b36ff75", "0633e466-21ba-4e0f-9a20-f1d096ff53e9" });
        }
    }
}
