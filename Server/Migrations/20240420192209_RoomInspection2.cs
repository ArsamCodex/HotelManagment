using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class RoomInspection2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomsInspection_rooms_RoomID",
                table: "roomsInspection");

            migrationBuilder.DropIndex(
                name: "IX_roomsInspection_RoomID",
                table: "roomsInspection");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "roomsInspection",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_roomsInspection_RoomID",
                table: "roomsInspection",
                column: "RoomID",
                unique: true,
                filter: "[RoomID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_roomsInspection_rooms_RoomID",
                table: "roomsInspection",
                column: "RoomID",
                principalTable: "rooms",
                principalColumn: "RoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomsInspection_rooms_RoomID",
                table: "roomsInspection");

            migrationBuilder.DropIndex(
                name: "IX_roomsInspection_RoomID",
                table: "roomsInspection");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "roomsInspection",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_roomsInspection_RoomID",
                table: "roomsInspection",
                column: "RoomID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_roomsInspection_rooms_RoomID",
                table: "roomsInspection",
                column: "RoomID",
                principalTable: "rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
