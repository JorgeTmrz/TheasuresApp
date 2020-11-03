using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea_Seis_y_Siete.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Correo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    ColorFav = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Correo);
                });

            migrationBuilder.CreateTable(
                name: "Tesoros",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Lugar = table.Column<string>(nullable: true),
                    URLReferencia = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    UsuarioCorreo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tesoros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tesoros_Usuarios_UsuarioCorreo",
                        column: x => x.UsuarioCorreo,
                        principalTable: "Usuarios",
                        principalColumn: "Correo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tesoros_UsuarioCorreo",
                table: "Tesoros",
                column: "UsuarioCorreo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tesoros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
