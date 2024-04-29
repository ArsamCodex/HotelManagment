using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class remclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kitchen_fooMenu_FoodMenuId",
                table: "kitchen");

            migrationBuilder.DropIndex(
                name: "IX_kitchen_FoodMenuId",
                table: "kitchen");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "70760a50-3945-4d98-b195-457d0e746768", "89d4b23e-bace-4319-836b-981205c0ecde" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70760a50-3945-4d98-b195-457d0e746768");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d4b23e-bace-4319-836b-981205c0ecde");

            migrationBuilder.DropColumn(
                name: "FoodMenuId",
                table: "kitchen");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TodayFood",
                table: "fooMenu",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Option3",
                table: "fooMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Option2",
                table: "fooMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Option1",
                table: "fooMenu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4653a983-e940-425f-9810-794b307c548b", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c6f7cfc-f84d-4f95-acd4-0acab03db93c", 0, "2a706f14-334a-4a00-b730-11c1da238991", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "acc92a04-c717-4b66-8da2-121fda6cf0fa", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4653a983-e940-425f-9810-794b307c548b", "6c6f7cfc-f84d-4f95-acd4-0acab03db93c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4653a983-e940-425f-9810-794b307c548b", "6c6f7cfc-f84d-4f95-acd4-0acab03db93c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4653a983-e940-425f-9810-794b307c548b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c6f7cfc-f84d-4f95-acd4-0acab03db93c");

            migrationBuilder.AddColumn<int>(
                name: "FoodMenuId",
                table: "kitchen",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TodayFood",
                table: "fooMenu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Option3",
                table: "fooMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Option2",
                table: "fooMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Option1",
                table: "fooMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70760a50-3945-4d98-b195-457d0e746768", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "89d4b23e-bace-4319-836b-981205c0ecde", 0, "03d048b5-30b2-49e3-9b94-95727f00e3ea", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "24e1dbbf-4195-4b60-93d4-298cbf547a0a", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "70760a50-3945-4d98-b195-457d0e746768", "89d4b23e-bace-4319-836b-981205c0ecde" });

            migrationBuilder.CreateIndex(
                name: "IX_kitchen_FoodMenuId",
                table: "kitchen",
                column: "FoodMenuId",
                unique: true,
                filter: "[FoodMenuId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_kitchen_fooMenu_FoodMenuId",
                table: "kitchen",
                column: "FoodMenuId",
                principalTable: "fooMenu",
                principalColumn: "FoodMenuId");
        }
    }
}
