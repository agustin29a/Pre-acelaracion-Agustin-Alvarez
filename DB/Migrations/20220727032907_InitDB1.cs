using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class InitDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    PersonajeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.PersonajeID);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    PeliculaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Clasificacion = table.Column<int>(type: "int", nullable: false),
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.PeliculaID);
                    table.ForeignKey(
                        name: "FK_Pelicula_Genero_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Genero",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaPersonaje",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaPersonaje", x => new { x.PersonajeId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "PeliculaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaPersonaje_Personaje_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personaje",
                        principalColumn: "PersonajeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_GeneroID",
                table: "Pelicula",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaPersonaje_PeliculaId",
                table: "PeliculaPersonaje",
                column: "PeliculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaPersonaje");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
