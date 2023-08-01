using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employment.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatelastEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 8, 1, 16, 26, 7, 144, DateTimeKind.Unspecified).AddTicks(6917), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 8, 1, 16, 26, 7, 143, DateTimeKind.Unspecified).AddTicks(3498), new TimeSpan(0, 6, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 8, 1, 16, 20, 30, 151, DateTimeKind.Unspecified).AddTicks(1503), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 8, 1, 16, 20, 30, 149, DateTimeKind.Unspecified).AddTicks(5767), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
