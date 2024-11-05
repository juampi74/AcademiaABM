namespace Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Persona
    {
        private int id_persona;

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        private string nombre;

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        private string apellido;

        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        private string direccion;

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        private string email;

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        private string telefono;

        [Required(ErrorMessage = "El campo FechaNacimiento es obligatorio.")]
        private DateTime fecha_nac;

        [Required(ErrorMessage = "El campo Legajo es obligatorio.")]
        private int legajo;

        [Required(ErrorMessage = "El campo TipoPersona es obligatorio.")]
        private int tipo_persona;

        // Clave foránea
        private int id_plan = 0;

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Plan Plan { get; set; }
        
        /*
        // Coleccion de Usuarios para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Usuario> Usuarios { get; set; }

        // Coleccion de Alumnos_Inscripciones para la Relacion N:M con Curso (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Alumno_Inscripcion> Alumno_Inscripciones { get; set; }

        // Coleccion de Docentes_Cursos para la Relacion N:M con Curso (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Docente_Curso> Docente_Cursos { get; set; }
        */

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

        public Persona() {}

        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public DateTime Fecha_nac
        {
            get { return fecha_nac; }
            set { fecha_nac = value; }
        }

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public int Tipo_persona
        {
            get { return tipo_persona; }
            set { tipo_persona = value; }
        }

        public int Id_plan
        {
            get { return id_plan; }
            set { id_plan = value; }
        }

    }
}