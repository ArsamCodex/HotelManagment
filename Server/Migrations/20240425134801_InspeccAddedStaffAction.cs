using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class InspeccAddedStaffAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c53f29b-cde8-40b6-ad5e-805b059e4c32", "8ad2def5-f3e1-4175-b292-eb88e2e9192d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c53f29b-cde8-40b6-ad5e-805b059e4c32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ad2def5-f3e1-4175-b292-eb88e2e9192d");

            migrationBuilder.AddColumn<string>(
                name: "StaffEndedAction",
                table: "roomsInspection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffStartedAction",
                table: "roomsInspection",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "824424fc-c5d8-4b59-b7e3-5c784285ccc6", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "76458d8d-3625-412f-b5fe-e5b4d249a241", 0, "9d17dff9-f59d-4d36-a33d-aedb82e650d8", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "cd378daa-1af1-4d7c-b206-9552923201b8", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "824424fc-c5d8-4b59-b7e3-5c784285ccc6", "76458d8d-3625-412f-b5fe-e5b4d249a241" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "824424fc-c5d8-4b59-b7e3-5c784285ccc6", "76458d8d-3625-412f-b5fe-e5b4d249a241" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824424fc-c5d8-4b59-b7e3-5c784285ccc6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76458d8d-3625-412f-b5fe-e5b4d249a241");

            migrationBuilder.DropColumn(
                name: "StaffEndedAction",
                table: "roomsInspection");

            migrationBuilder.DropColumn(
                name: "StaffStartedAction",
                table: "roomsInspection");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c53f29b-cde8-40b6-ad5e-805b059e4c32", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8ad2def5-f3e1-4175-b292-eb88e2e9192d", 0, "9963156e-a405-4545-85f4-f39794eb16e9", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "dd677322-c027-4c4c-a811-9ac88d6a7286", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4c53f29b-cde8-40b6-ad5e-805b059e4c32", "8ad2def5-f3e1-4175-b292-eb88e2e9192d" });
        }
    }
}
