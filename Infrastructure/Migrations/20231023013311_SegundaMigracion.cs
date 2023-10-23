using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEmision",
                table: "Serie",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmisionSerie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmisionSerie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmisionSerie_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmisionSerie_SerieId",
                table: "EmisionSerie",
                column: "SerieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmisionSerie");

            migrationBuilder.DropColumn(
                name: "FechaEmision",
                table: "Serie");
        }
    }
}
