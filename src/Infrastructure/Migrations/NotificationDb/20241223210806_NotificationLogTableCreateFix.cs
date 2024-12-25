using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.NotificationDb
{
    /// <inheritdoc />
    public partial class NotificationLogTableCreateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationLog_NotificationChannels_NotificationChannelId",
                table: "NotificationLog");

            migrationBuilder.DropIndex(
                name: "IX_NotificationLog_NotificationChannelId",
                table: "NotificationLog");

            migrationBuilder.DropColumn(
                name: "NotificationChannelId",
                table: "NotificationLog");

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("061898e6-c619-4f9e-96fc-f517e18f1fe7"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 23, 21, 8, 5, 371, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("829fe06a-2fa2-477c-979d-d1080ca86bbc"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 23, 21, 8, 5, 371, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("cf7d73aa-c172-4eb2-9782-5491c76018b9"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 23, 21, 8, 5, 371, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLog_ChannelId",
                table: "NotificationLog",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationLog_NotificationChannels_ChannelId",
                table: "NotificationLog",
                column: "ChannelId",
                principalTable: "NotificationChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationLog_NotificationChannels_ChannelId",
                table: "NotificationLog");

            migrationBuilder.DropIndex(
                name: "IX_NotificationLog_ChannelId",
                table: "NotificationLog");

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationChannelId",
                table: "NotificationLog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("061898e6-c619-4f9e-96fc-f517e18f1fe7"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 23, 20, 42, 34, 425, DateTimeKind.Utc).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("829fe06a-2fa2-477c-979d-d1080ca86bbc"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 23, 20, 42, 34, 425, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("cf7d73aa-c172-4eb2-9782-5491c76018b9"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 23, 20, 42, 34, 425, DateTimeKind.Utc).AddTicks(353));

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLog_NotificationChannelId",
                table: "NotificationLog",
                column: "NotificationChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationLog_NotificationChannels_NotificationChannelId",
                table: "NotificationLog",
                column: "NotificationChannelId",
                principalTable: "NotificationChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
