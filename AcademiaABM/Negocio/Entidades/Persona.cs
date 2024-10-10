namespace AcademiaABM.Negocio.Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Persona
    {
        private int id_persona;
        private string nombre;
        private string apellido;
        private string direccion;
        private string email;
        private string telefono;
        private DateTime fecha_nac;
        private int? legajo;
        private int tipo_persona;

        // Clave foránea
        private int? id_plan;

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

        public Persona(string nombre, string apellido, string direccion, string email, string telefono, DateTime fecha_nac, int tipo_persona)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Email = email;
            this.Telefono = telefono;
            this.Fecha_nac = fecha_nac;
            this.Tipo_persona = tipo_persona;
        }

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

        public int? Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public int Tipo_persona
        {
            get { return tipo_persona; }
            set { tipo_persona = value; }
        }

        public int? Id_plan
        {
            get { return id_plan; }
            set { id_plan = value; }
        }

    }
}