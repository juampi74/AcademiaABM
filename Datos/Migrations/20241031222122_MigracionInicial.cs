using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id_especialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id_especialidad);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id_plan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_plan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_especialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id_plan);
                    table.ForeignKey(
                        name: "FK_Planes_Especialidades_Id_especialidad",
                        column: x => x.Id_especialidad,
                        principalTable: "Especialidades",
                        principalColumn: "Id_especialidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comisiones",
                columns: table => new
                {
                    Id_comision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_comision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anio_especialidad = table.Column<int>(type: "int", nullable: false),
                    Id_plan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comisiones", x => x.Id_comision);
                    table.ForeignKey(
                        name: "FK_Comisiones_Planes_Id_plan",
                        column: x => x.Id_plan,
                        principalTable: "Planes",
                        principalColumn: "Id_plan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id_materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hs_semanales = table.Column<int>(type: "int", nullable: false),
                    Hs_totales = table.Column<int>(type: "int", nullable: false),
                    Id_plan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id_materia);
                    table.ForeignKey(
                        name: "FK_Materias_Planes_Id_plan",
                        column: x => x.Id_plan,
                        principalTable: "Planes",
                        principalColumn: "Id_plan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_nac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Legajo = table.Column<int>(type: "int", nullable: false),
                    Tipo_persona = table.Column<int>(type: "int", nullable: false),
                    Id_plan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id_persona);
                    table.ForeignKey(
                        name: "FK_Personas_Planes_Id_plan",
                        column: x => x.Id_plan,
                        principalTable: "Planes",
                        principalColumn: "Id_plan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio_calendario = table.Column<int>(type: "int", nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    Id_comision = table.Column<int>(type: "int", nullable: false),
                    Id_materia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id_curso);
                    table.ForeignKey(
                        name: "FK_Cursos_Comisiones_Id_comision",
                        column: x => x.Id_comision,
                        principalTable: "Comisiones",
                        principalColumn: "Id_comision",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cursos_Materias_Id_materia",
                        column: x => x.Id_materia,
                        principalTable: "Materias",
                        principalColumn: "Id_materia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilitado = table.Column<int>(type: "int", nullable: false),
                    Cambia_clave = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Id_persona = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_Id_persona",
                        column: x => x.Id_persona,
                        principalTable: "Personas",
                        principalColumn: "Id_persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos_Inscripciones",
                columns: table => new
                {
                    Id_inscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Id_alumno = table.Column<int>(type: "int", nullable: false),
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos_Inscripciones", x => x.Id_inscripcion);
                    table.ForeignKey(
                        name: "FK_Alumnos_Inscripciones_Cursos_Id_curso",
                        column: x => x.Id_curso,
                        principalTable: "Cursos",
                        principalColumn: "Id_curso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumnos_Inscripciones_Personas_Id_alumno",
                        column: x => x.Id_alumno,
                        principalTable: "Personas",
                        principalColumn: "Id_persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Docentes_cursos",
                columns: table => new
                {
                    Id_dictado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_docente = table.Column<int>(type: "int", nullable: false),
                    Id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes_cursos", x => x.Id_dictado);
                    table.ForeignKey(
                        name: "FK_Docentes_cursos_Cursos_Id_curso",
                        column: x => x.Id_curso,
                        principalTable: "Cursos",
                        principalColumn: "Id_curso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Docentes_cursos_Personas_Id_docente",
                        column: x => x.Id_docente,
                        principalTable: "Personas",
                        principalColumn: "Id_persona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_Inscripciones_Id_alumno",
                table: "Alumnos_Inscripciones",
                column: "Id_alumno");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_Inscripciones_Id_curso",
                table: "Alumnos_Inscripciones",
                column: "Id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_Id_plan",
                table: "Comisiones",
                column: "Id_plan");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Id_comision",
                table: "Cursos",
                column: "Id_comision");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Id_materia",
                table: "Cursos",
                column: "Id_materia");

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_cursos_Id_curso",
                table: "Docentes_cursos",
                column: "Id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_cursos_Id_docente",
                table: "Docentes_cursos",
                column: "Id_docente");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Id_plan",
                table: "Materias",
                column: "Id_plan");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Id_plan",
                table: "Personas",
                column: "Id_plan");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_Id_especialidad",
                table: "Planes",
                column: "Id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_persona",
                table: "Usuarios",
                column: "Id_persona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos_Inscripciones");

            migrationBuilder.DropTable(
                name: "Docentes_cursos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Comisiones");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
