using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasoEstudio1_G1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rutas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 26, 18, 51, 46, 185, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Rutas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 26, 18, 51, 46, 185, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 26, 18, 51, 46, 185, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 26, 18, 51, 46, 185, DateTimeKind.Local).AddTicks(6556));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rutas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Rutas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5222));
        }
    }
}
