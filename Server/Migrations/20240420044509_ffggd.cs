using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class ffggd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservation_rooms_RoomID",
                table: "reservation");

            migrationBuilder.DropIndex(
                name: "IX_reservation_RoomID",
                table: "reservation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_reservation_RoomID",
                table: "reservation",
                column: "RoomID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reservation_rooms_RoomID",
                table: "reservation",
                column: "RoomID",
                principalTable: "rooms",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
