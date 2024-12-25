using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations.NotificationDb
{
    /// <inheritdoc />
    public partial class Notification_Channel_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NotificationChannels",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("061898e6-c619-4f9e-96fc-f517e18f1fe7"), new DateTime(2024, 12, 22, 15, 36, 1, 716, DateTimeKind.Utc).AddTicks(1036), null, false, "SMS", null },
                    { new Guid("829fe06a-2fa2-477c-979d-d1080ca86bbc"), new DateTime(2024, 12, 22, 15, 36, 1, 716, DateTimeKind.Utc).AddTicks(1060), null, false, "PUSH", null },
                    { new Guid("cf7d73aa-c172-4eb2-9782-5491c76018b9"), new DateTime(2024, 12, 22, 15, 36, 1, 716, DateTimeKind.Utc).AddTicks(1024), null, false, "E-MAIL", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("061898e6-c619-4f9e-96fc-f517e18f1fe7"));

            migrationBuilder.DeleteData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("829fe06a-2fa2-477c-979d-d1080ca86bbc"));

            migrationBuilder.DeleteData(
                table: "NotificationChannels",
                keyColumn: "Id",
                keyValue: new Guid("cf7d73aa-c172-4eb2-9782-5491c76018b9"));
        }
    }
}
