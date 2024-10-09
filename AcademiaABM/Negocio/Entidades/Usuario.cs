namespace AcademiaABM.Negocio.Entidades
{
    using System.ComponentModel;

    public class Usuario
    {
        public int Id_usuario { get; set; }
        public string Nombre_usuario { get; set; }
        public string Clave { get; set; }
        public int Habilitado { get; set; }
        public int Cambia_clave { get; set; }
        public string Rol { get; set; } // 'Alumno', 'Docente', 'Administrador'

        // Clave foránea
        public int? Id_persona { get; set; } // Puede ser null si el usuario es Administrador

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Persona? Persona { get; set; } // Puede ser null si el usuario es Administrador

        public Usuario(string nombre_usuario, string clave, int habilitado, int cambia_clave, string rol, int id_persona)
        {
            this.Nombre_usuario = nombre_usuario;
            this.Clave = clave;
            this.Habilitado = habilitado;
            this.Cambia_clave = cambia_clave;
            this.Rol = rol;
            this.Id_persona = id_persona;
        }

        public Usuario(string nombre_usuario, string clave, int habilitado, int cambia_clave, string rol)
        {
            this.Nombre_usuario = nombre_usuario;
            this.Clave = clave;
            this.Habilitado = habilitado;
            this.Cambia_clave = cambia_clave;
            this.Rol = rol;
        }
    }
}