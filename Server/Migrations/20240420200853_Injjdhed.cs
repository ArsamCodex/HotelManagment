using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class Injjdhed : Migration
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

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "roomsInspection");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionDate",
                table: "roomsInspection",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionDate",
                table: "roomsInspection",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "roomsInspection",
                type: "int",
                nullable: true);

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
    }
}
