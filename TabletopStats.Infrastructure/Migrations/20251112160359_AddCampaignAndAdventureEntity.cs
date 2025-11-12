using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopStats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaignAndAdventureEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdventureId",
                table: "SessionLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SessionLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RpgSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adventures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adventures_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_AdventureId",
                table: "SessionLogs",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_Adventures_CampaignId",
                table: "Adventures",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionLogs_Adventures_AdventureId",
                table: "SessionLogs",
                column: "AdventureId",
                principalTable: "Adventures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionLogs_Adventures_AdventureId",
                table: "SessionLogs");

            migrationBuilder.DropTable(
                name: "Adventures");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_SessionLogs_AdventureId",
                table: "SessionLogs");

            migrationBuilder.DropColumn(
                name: "AdventureId",
                table: "SessionLogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SessionLogs");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RpgSystems");
        }
    }
}
