using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopStats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RpgSystems",
                columns: table => new
                {
                    SystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpgSystems", x => x.SystemId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionInfoSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionInfos",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RpgSystemSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionInfos", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_SessionInfos_Persons_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionInfos_RpgSystems_RpgSystemSystemId",
                        column: x => x.RpgSystemSystemId,
                        principalTable: "RpgSystems",
                        principalColumn: "SystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SessionInfoSessionId",
                table: "Persons",
                column: "SessionInfoSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfos_GameMasterId",
                table: "SessionInfos",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfos_RpgSystemSystemId",
                table: "SessionInfos",
                column: "RpgSystemSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_SessionInfos_SessionInfoSessionId",
                table: "Persons",
                column: "SessionInfoSessionId",
                principalTable: "SessionInfos",
                principalColumn: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_SessionInfos_SessionInfoSessionId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "SessionInfos");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RpgSystems");
        }
    }
}
