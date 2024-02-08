using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketProject.Data.Migrations
{
    public partial class TicketModelsdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketSystemCategoryTypes",
                columns: table => new
                {
                    TicketSystemCategoryTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSystemCategoryTypes", x => x.TicketSystemCategoryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TicketEntries",
                columns: table => new
                {
                    TicketEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketSystemCategoryTypeID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketEntries", x => x.TicketEntryID);
                    table.ForeignKey(
                        name: "FK_TicketEntries_TicketSystemCategoryTypes_TicketSystemCategoryTypeID",
                        column: x => x.TicketSystemCategoryTypeID,
                        principalTable: "TicketSystemCategoryTypes",
                        principalColumn: "TicketSystemCategoryTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketEntries_TicketSystemCategoryTypeID",
                table: "TicketEntries",
                column: "TicketSystemCategoryTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketEntries");

            migrationBuilder.DropTable(
                name: "TicketSystemCategoryTypes");
        }
    }
}
