using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class firsty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomsInspection_repair_RepairID",
                table: "roomsInspection");

            migrationBuilder.DropIndex(
                name: "IX_roomsInspection_RepairID",
                table: "roomsInspection");

            migrationBuilder.DropColumn(
                name: "RepairID",
                table: "roomsInspection");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepairID",
                table: "roomsInspection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_roomsInspection_RepairID",
                table: "roomsInspection",
                column: "RepairID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_roomsInspection_repair_RepairID",
                table: "roomsInspection",
                column: "RepairID",
                principalTable: "repair",
                principalColumn: "RepairID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
