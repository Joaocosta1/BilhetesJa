using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class AddedProducer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Identifier = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp(0)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointOfSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatorId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp(0)", nullable: false),
                    UpdaterId = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp(0)", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    TerminalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfSale_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointOfSale_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointOfSale_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointOfSale_Terminal_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointOfSale_AspNetUsers_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ProducerId",
                table: "Events",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfSale_ApplicationUserId",
                table: "PointOfSale",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfSale_CreatorId",
                table: "PointOfSale",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfSale_EventId",
                table: "PointOfSale",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfSale_TerminalId",
                table: "PointOfSale",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfSale_UpdaterId",
                table: "PointOfSale",
                column: "UpdaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Producer_ProducerId",
                table: "Events",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Producer_ProducerId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "PointOfSale");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropIndex(
                name: "IX_Events_ProducerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Events");
        }
    }
}
