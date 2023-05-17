using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GSN.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WeatherForecasts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TemperatureC = table.Column<int>(type: "INTEGER", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: "5b1c2b4d-48c7-402a-80c3-cc796ad49c6b",
                column: "CreatedOnDate",
                value: new DateTime(2023, 5, 17, 19, 49, 10, 975, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: "d28888e9-2ba9-473a-a40f-e38cb54f9b35",
                column: "CreatedOnDate",
                value: new DateTime(2023, 5, 17, 19, 49, 10, 975, DateTimeKind.Utc).AddTicks(7174));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { "1ad122b9-809f-4a5b-9f9d-784269a9c43c", new DateOnly(2023, 5, 18), "Partly Cloudy", 22 },
                    { "381c4b1c-1d85-4b7a-943b-d87aae6aff8b", new DateOnly(2023, 5, 17), "Sunny", 20 },
                    { "8bd23f52-a7d9-4e97-bd97-2dd8831336bc", new DateOnly(2023, 5, 22), "Rainy", 25 },
                    { "cff114a5-2929-4017-87d0-7933a742abce", new DateOnly(2023, 5, 19), "Sunny Cloudy", 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: "5b1c2b4d-48c7-402a-80c3-cc796ad49c6b",
                column: "CreatedOnDate",
                value: new DateTime(2023, 5, 17, 10, 55, 12, 397, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: "d28888e9-2ba9-473a-a40f-e38cb54f9b35",
                column: "CreatedOnDate",
                value: new DateTime(2023, 5, 17, 10, 55, 12, 397, DateTimeKind.Utc).AddTicks(1502));
        }
    }
}
