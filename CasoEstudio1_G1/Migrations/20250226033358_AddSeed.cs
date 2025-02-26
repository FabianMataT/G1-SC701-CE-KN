using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CasoEstudio1_G1.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Bueno" },
                    { 2, "Regular" },
                    { 3, "Necesita mantenimiento" }
                });

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "Id", "Hora" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 12, 0, 0, 0) },
                    { 3, new TimeSpan(0, 18, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Paradas",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Parada 1" },
                    { 2, "Parada 2" },
                    { 3, "Parada 3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Conductor" },
                    { 3, "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contrasenna", "Correo", "NombreCompleto", "NombreUsuario", "RolId", "Telefono" },
                values: new object[,]
                {
                    { 1, "12345678", "fabian@gmail.com", "Fabian Mata", "fabi", 1, "684634524" },
                    { 2, "12345678", "rodolfo@gmail.com", "Rodolfo Cruz", "rodo", 1, "96939564" },
                    { 3, "12345678", "maria@gmail.com", "Maria Canales", "mari", 2, "35784925" },
                    { 4, "12345678", "cristopher@gmail.com", "Cristopher Nuñez", "cris", 3, "684634524" }
                });

            migrationBuilder.InsertData(
                table: "Rutas",
                columns: new[] { "Id", "Descripcion", "Estado", "FechaRegistro", "NombreRuta", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Ruta principal", true, new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5166), "Ruta 1", 1 },
                    { 2, "Ruta secundaria", true, new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5177), "Ruta 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "HorariosRutas",
                columns: new[] { "Id", "HorarioId", "RutaId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ParadasRutas",
                columns: new[] { "Id", "ParadaId", "RutaId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "Id", "CapacidadPasajeros", "EstadoId", "FechaRegistro", "Modelo", "Placa", "RutaId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 50, 1, new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5219), "Modelo X", "ABC123", 1, 1 },
                    { 2, 40, 2, new DateTime(2025, 2, 25, 21, 33, 58, 207, DateTimeKind.Local).AddTicks(5222), "Modelo Y", "DEF456", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Boletos",
                columns: new[] { "Id", "UsuarioId", "VehiculoId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boletos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boletos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HorariosRutas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HorariosRutas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParadasRutas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParadasRutas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParadasRutas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paradas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paradas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paradas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rutas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rutas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
