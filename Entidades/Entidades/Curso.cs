﻿namespace Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Curso
    {
        public int Id_curso { get; set; }

        [Required(ErrorMessage = "El campo Año Calendario es obligatorio.")]
        public int Anio_calendario { get; set; }

        [Required(ErrorMessage = "El campo Cupo es obligatorio.")]
        public int Cupo { get; set; }

        // Claves foráneas
        [Required(ErrorMessage = "El campo Comision es obligatorio.")]
        public int Id_comision { get; set; }

        [Required(ErrorMessage = "El campo Materia es obligatorio.")]
        public int Id_materia { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Comision Comision { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Materia Materia { get; set; }

        /*
        // Coleccion de Alumnos_Inscripciones para la Relacion N:M con Persona (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Alumno_Inscripcion> Alumno_Inscripciones { get; set; }

        // Coleccion de Docentes_Cursos para la Relacion N:M con Persona (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Docente_Curso> Docente_Cursos { get; set; }
        */

        public Curso(int anio_calendario, int cupo, int id_comision, int id_materia)
        {
            this.Anio_calendario = anio_calendario;
            this.Cupo = cupo;
            this.Id_comision = id_comision;
            this.Id_materia = id_materia;
        }

        public Curso() {}
    }
}