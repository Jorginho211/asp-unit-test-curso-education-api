using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("02e4ffd8-5e78-40ad-b3e9-87051fad3589"), "Curso de c# basico", new DateTime(2022, 4, 21, 10, 36, 59, 737, DateTimeKind.Local).AddTicks(8519), new DateTime(2024, 4, 21, 10, 36, 59, 737, DateTimeKind.Local).AddTicks(8554), 56m, "C# desde cero hasta avanzado" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("cb71db42-7372-41a7-8b3a-6258175686a2"), "Curso de Java", new DateTime(2022, 4, 21, 10, 36, 59, 737, DateTimeKind.Local).AddTicks(8577), new DateTime(2024, 4, 21, 10, 36, 59, 737, DateTimeKind.Local).AddTicks(8579), 25m, "Master en Java Spring desde las raices" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("f9098ddc-df6f-46de-94fe-726bf7464821"), "Curso de Unit Test para NET Core", new DateTime(2022, 4, 21, 10, 36, 59, 737, DateTimeKind.Local).AddTicks(8587), new DateTime(2024, 4, 21, 10, 36, 59, 737, DateTimeKind.Local).AddTicks(8589), 25m, "Master en UNIT Test con CQRS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
