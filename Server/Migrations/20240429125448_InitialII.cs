using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b991502d-1f9f-4fc4-ac7c-26a2d79c97c5", "b582358b-9cd0-486c-9cee-15f3ccdadb84" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b991502d-1f9f-4fc4-ac7c-26a2d79c97c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b582358b-9cd0-486c-9cee-15f3ccdadb84");

            migrationBuilder.CreateTable(
                name: "fooMenu",
                columns: table => new
                {
                    FoodMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fooMenu", x => x.FoodMenuId);
                });

            migrationBuilder.CreateTable(
                name: "kitchen",
                columns: table => new
                {
                    KitchenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemsInitchen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissingIngredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Staff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodMenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitchen", x => x.KitchenId);
                    table.ForeignKey(
                        name: "FK_kitchen_fooMenu_FoodMenuId",
                        column: x => x.FoodMenuId,
                        principalTable: "fooMenu",
                        principalColumn: "FoodMenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04e6b683-860a-4c3d-9938-5bdf3d1c1a1d", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f090c11-3376-435b-99f5-569c1f4e9894", 0, "cb6a5c84-3699-462e-abb2-444b07ebf42f", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "7a932966-4c31-422a-be36-7c9cc61a4660", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "04e6b683-860a-4c3d-9938-5bdf3d1c1a1d", "9f090c11-3376-435b-99f5-569c1f4e9894" });

            migrationBuilder.CreateIndex(
                name: "IX_kitchen_FoodMenuId",
                table: "kitchen",
                column: "FoodMenuId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kitchen");

            migrationBuilder.DropTable(
                name: "fooMenu");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04e6b683-860a-4c3d-9938-5bdf3d1c1a1d", "9f090c11-3376-435b-99f5-569c1f4e9894" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04e6b683-860a-4c3d-9938-5bdf3d1c1a1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f090c11-3376-435b-99f5-569c1f4e9894");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b991502d-1f9f-4fc4-ac7c-26a2d79c97c5", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b582358b-9cd0-486c-9cee-15f3ccdadb84", 0, "c7689e36-a90b-4365-808b-249341e1c83f", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "f8531a77-7a7d-4ad5-b07f-33485fa68dea", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b991502d-1f9f-4fc4-ac7c-26a2d79c97c5", "b582358b-9cd0-486c-9cee-15f3ccdadb84" });
        }
    }
}
