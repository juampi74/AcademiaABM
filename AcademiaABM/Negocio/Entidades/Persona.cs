namespace AcademiaABM.Negocio.Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Persona
    {
        public int Id_persona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_nac { get; set; }
        public int Legajo { get; set; }
        public int Tipo_persona { get; set; }

        // Clave foránea
        public int Id_plan { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Plan Plan { get; set; }

        // Coleccion de Usuarios para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Usuario> Usuarios { get; set; }

        // Coleccion de Alumnos_Inscripciones para la Relacion N:M con Curso (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Alumno_Inscripcion> Alumno_Inscripciones { get; set; }

        // Coleccion de Docentes_Cursos para la Relacion N:M con Curso (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Docente_Curso> Docente_Cursos { get; set; }

        public Persona(string nombre, string apellido, string direccion, string email, string telefono, DateTime fecha_nac, int legajo, int tipo_persona, int id_plan)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Email = email;
            this.Telefono = telefono;
            this.Fecha_nac = fecha_nac;
            this.Legajo = legajo;
            this.Tipo_persona = tipo_persona;
            this.Id_plan = id_plan;
        }
    }
}