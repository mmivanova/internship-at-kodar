using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketManager.Migrations
{
    public partial class TicketModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Tickets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Tickets",
                type: "int",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tickets_AppUserId",
                table: "AspNetUsers",
                column: "AppUserId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tickets_AppUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Tickets");
        }
    }
}
