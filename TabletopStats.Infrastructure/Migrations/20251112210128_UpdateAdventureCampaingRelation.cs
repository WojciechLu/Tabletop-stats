using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopStats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdventureCampaingRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventures_Campaigns_CampaignId",
                table: "Adventures");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampaignId",
                table: "Adventures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adventures_Campaigns_CampaignId",
                table: "Adventures",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventures_Campaigns_CampaignId",
                table: "Adventures");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampaignId",
                table: "Adventures",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Adventures_Campaigns_CampaignId",
                table: "Adventures",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");
        }
    }
}
