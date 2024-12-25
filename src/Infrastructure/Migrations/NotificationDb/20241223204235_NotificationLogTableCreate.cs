using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.NotificationDb
{
    /// <inheritdoc />
    public partial class NotificationLogTableCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationLog_NotificationChannels_NotificationChannelId",
                        column: x => x.NotificationChannelId,
                        principalTable: "NotificationChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationLog_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 20, 42, 34, 425, DateTimeKind.Utc).AddTicks(353), "EMAIL" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLog_NotificationChannelId",
                table: "NotificationLog",
                column: "NotificationChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLog_NotificationId",
                table: "NotificationLog",
                column: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationLog");

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("061898e6-c619-4f9e-96fc-f517e18f1fe7"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 15, 36, 1, 716, DateTimeKind.Utc).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("829fe06a-2fa2-477c-979d-d1080ca86bbc"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 15, 36, 1, 716, DateTimeKind.Utc).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("cf7d73aa-c172-4eb2-9782-5491c76018b9"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 12, 22, 15, 36, 1, 716, DateTimeKind.Utc).AddTicks(1024), "E-MAIL" });
        }
    }
}
