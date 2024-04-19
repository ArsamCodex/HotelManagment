using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Secss : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "rooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "HowMannhyPersons",
                table: "rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "HowMannhyPersons",
                table: "rooms");

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
