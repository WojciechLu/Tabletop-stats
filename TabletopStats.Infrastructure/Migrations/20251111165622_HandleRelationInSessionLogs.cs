using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopStats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HandleRelationInSessionLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_SessionInfos_SessionInfoSessionId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "SessionInfos");

            migrationBuilder.DropIndex(
                name: "IX_Persons_SessionInfoSessionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SessionInfoSessionId",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "SessionLogs",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RpgSystemSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionLogs", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_SessionLogs_Persons_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SessionLogs_RpgSystems_RpgSystemSystemId",
                        column: x => x.RpgSystemSystemId,
                        principalTable: "RpgSystems",
                        principalColumn: "SystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSessionLog",
                columns: table => new
                {
                    PlayersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionPlayedSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSessionLog", x => new { x.PlayersId, x.SessionPlayedSessionId });
                    table.ForeignKey(
                        name: "FK_PlayerSessionLog_Persons_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSessionLog_SessionLogs_SessionPlayedSessionId",
                        column: x => x.SessionPlayedSessionId,
                        principalTable: "SessionLogs",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSessionLog_SessionPlayedSessionId",
                table: "PlayerSessionLog",
                column: "SessionPlayedSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_GameMasterId",
                table: "SessionLogs",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_RpgSystemSystemId",
                table: "SessionLogs",
                column: "RpgSystemSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSessionLog");

            migrationBuilder.DropTable(
                name: "SessionLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionInfoSessionId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SessionInfos",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RpgSystemSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
    }
}
