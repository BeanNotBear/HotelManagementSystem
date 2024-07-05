using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Rename_RommStatus_To_RoomStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RommStatus_StatusId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RommStatus",
                table: "RommStatus");

            migrationBuilder.RenameTable(
                name: "RommStatus",
                newName: "RoomStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomStatus",
                table: "RoomStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomStatus_StatusId",
                table: "Room",
                column: "StatusId",
                principalTable: "RoomStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomStatus_StatusId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomStatus",
                table: "RoomStatus");

            migrationBuilder.RenameTable(
                name: "RoomStatus",
                newName: "RommStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RommStatus",
                table: "RommStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RommStatus_StatusId",
                table: "Room",
                column: "StatusId",
                principalTable: "RommStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
