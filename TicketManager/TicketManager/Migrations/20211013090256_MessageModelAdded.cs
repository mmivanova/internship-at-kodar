using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketManager.Migrations
{
    public partial class MessageModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tickets");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.InsertData(
            //    table: "Receivers",
            //    columns: new[] { "Id", "Title" },
            //    values: new object[] { 4, "OfficeManager" });

            //migrationBuilder.InsertData(
            //    table: "Receivers",
            //    columns: new[] { "Id", "Title" },
            //    values: new object[] { 5, "TechnicalManager" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TicketId",
                table: "Messages",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Receivers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tickets");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Tickets",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "Id", "Title" },
                values: new object[] { 0, "TechnicalManager" });

            migrationBuilder.InsertData(
                table: "Receivers",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "OfficeManager" });
        }
    }
}
