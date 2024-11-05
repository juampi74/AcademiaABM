﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(UniversidadContext))]
    [Migration("20241031222122_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entidades.Alumno_Inscripcion", b =>
                {
                    b.Property<int>("Id_inscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_inscripcion"));

                    b.Property<string>("Condicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_alumno")
                        .HasColumnType("int");

                    b.Property<int>("Id_curso")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id_inscripcion");

                    b.HasIndex("Id_alumno");

                    b.HasIndex("Id_curso");

                    b.ToTable("Alumnos_Inscripciones");
                });

            modelBuilder.Entity("Entidades.Comision", b =>
                {
                    b.Property<int>("Id_comision")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_comision"));

                    b.Property<int>("Anio_especialidad")
                        .HasColumnType("int");

                    b.Property<string>("Desc_comision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_plan")
                        .HasColumnType("int");

                    b.HasKey("Id_comision");

                    b.HasIndex("Id_plan");

                    b.ToTable("Comisiones");
                });

            modelBuilder.Entity("Entidades.Curso", b =>
                {
                    b.Property<int>("Id_curso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_curso"));

                    b.Property<int>("Anio_calendario")
                        .HasColumnType("int");

                    b.Property<int>("Cupo")
                        .HasColumnType("int");

                    b.Property<int>("Id_comision")
                        .HasColumnType("int");

                    b.Property<int>("Id_materia")
                        .HasColumnType("int");

                    b.HasKey("Id_curso");

                    b.HasIndex("Id_comision");

                    b.HasIndex("Id_materia");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Entidades.Docente_Curso", b =>
                {
                    b.Property<int>("Id_dictado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_dictado"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_curso")
                        .HasColumnType("int");

                    b.Property<int>("Id_docente")
                        .HasColumnType("int");

                    b.HasKey("Id_dictado");

                    b.HasIndex("Id_curso");

                    b.HasIndex("Id_docente");

                    b.ToTable("Docentes_cursos");
                });

            modelBuilder.Entity("Entidades.Especialidad", b =>
                {
                    b.Property<int>("Id_especialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_especialidad"));

                    b.Property<string>("Desc_especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_especialidad");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Entidades.Materia", b =>
                {
                    b.Property<int>("Id_materia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_materia"));

                    b.Property<string>("Desc_materia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hs_semanales")
                        .HasColumnType("int");

                    b.Property<int>("Hs_totales")
                        .HasColumnType("int");

                    b.Property<int>("Id_plan")
                        .HasColumnType("int");

                    b.HasKey("Id_materia");

                    b.HasIndex("Id_plan");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Entidades.Persona", b =>
                {
                    b.Property<int>("Id_persona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_persona"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_nac")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_plan")
                        .HasColumnType("int");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo_persona")
                        .HasColumnType("int");

                    b.HasKey("Id_persona");

                    b.HasIndex("Id_plan");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entidades.Plan", b =>
                {
                    b.Property<int>("Id_plan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_plan"));

                    b.Property<string>("Desc_plan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_especialidad")
                        .HasColumnType("int");

                    b.HasKey("Id_plan");

                    b.HasIndex("Id_especialidad");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.Property<int>("Id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_usuario"));

                    b.Property<int>("Cambia_clave")
                        .HasColumnType("int");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Habilitado")
                        .HasColumnType("int");

                    b.Property<int?>("Id_persona")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id_usuario");

                    b.HasIndex("Id_persona");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entidades.Alumno_Inscripcion", b =>
                {
                    b.HasOne("Entidades.Persona", "Alumno")
                        .WithMany()
                        .HasForeignKey("Id_alumno")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entidades.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("Id_curso")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Entidades.Comision", b =>
                {
                    b.HasOne("Entidades.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("Id_plan")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Entidades.Curso", b =>
                {
                    b.HasOne("Entidades.Comision", "Comision")
                        .WithMany()
                        .HasForeignKey("Id_comision")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entidades.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("Id_materia")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comision");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Entidades.Docente_Curso", b =>
                {
                    b.HasOne("Entidades.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("Id_curso")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entidades.Persona", "Docente")
                        .WithMany()
                        .HasForeignKey("Id_docente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("Entidades.Materia", b =>
                {
                    b.HasOne("Entidades.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("Id_plan")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Entidades.Persona", b =>
                {
                    b.HasOne("Entidades.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("Id_plan")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Entidades.Plan", b =>
                {
                    b.HasOne("Entidades.Especialidad", "Especialidad")
                        .WithMany()
                        .HasForeignKey("Id_especialidad")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Entidades.Usuario", b =>
                {
                    b.HasOne("Entidades.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("Id_persona")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Persona");
                });
#pragma warning restore 612, 618
        }
    }
}
