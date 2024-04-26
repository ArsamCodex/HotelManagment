using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class ffhggd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_reception_ReceptionId",
                table: "post");

            migrationBuilder.DropTable(
                name: "reception");

            migrationBuilder.DropIndex(
                name: "IX_post_ReceptionId",
                table: "post");

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

            migrationBuilder.DropColumn(
                name: "ReceptionId",
                table: "post");

            migrationBuilder.AddColumn<string>(
                name: "StaffId",
                table: "post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "post");

            migrationBuilder.AddColumn<int>(
                name: "ReceptionId",
                table: "post",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_post_reception_ReceptionId",
                table: "post",
                column: "ReceptionId",
                principalTable: "reception",
                principalColumn: "ReceptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
