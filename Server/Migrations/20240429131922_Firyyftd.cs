using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class Firyyftd : Migration
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
                keyValues: new object[] { "c92f9468-cc17-41bc-b77c-86852bc1dd17", "59860352-770b-494a-9236-c215f9557f8b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c92f9468-cc17-41bc-b77c-86852bc1dd17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59860352-770b-494a-9236-c215f9557f8b");

            migrationBuilder.AlterColumn<int>(
                name: "FoodMenuId",
                table: "kitchen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "FoodMenuId",
                table: "kitchen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c92f9468-cc17-41bc-b77c-86852bc1dd17", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "59860352-770b-494a-9236-c215f9557f8b", 0, "428d589d-1bdc-468f-99ff-49245c078305", "newuser@example.com", true, false, null, "NEWUSER@EXAMPLE.COM", "NEWUSER@EXAMPLE.COM", "YourPasswordHashHere", null, false, "71a313cd-a09c-4ba9-88ed-66845c5319ac", false, "newuser@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c92f9468-cc17-41bc-b77c-86852bc1dd17", "59860352-770b-494a-9236-c215f9557f8b" });

            migrationBuilder.CreateIndex(
                name: "IX_kitchen_FoodMenuId",
                table: "kitchen",
                column: "FoodMenuId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_kitchen_fooMenu_FoodMenuId",
                table: "kitchen",
                column: "FoodMenuId",
                principalTable: "fooMenu",
                principalColumn: "FoodMenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
