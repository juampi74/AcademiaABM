namespace Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Usuario
    {
        public int Id_usuario { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Usuario es obligatorio.")]
        public string Nombre_usuario { get; set; }

        [Required(ErrorMessage = "El campo Clave es obligatorio.")]
        public string Clave { get; set; }

        public int Rol { get; set; }

        // Clave foránea
        public int? Id_persona { get; set; }


        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Persona? Persona { get; set; }

        public Usuario(string nombre_usuario, string clave, int rol, int id_persona)
        {
            this.Nombre_usuario = nombre_usuario;
            this.Clave = clave;
            this.Rol = rol;
            this.Id_persona = id_persona;

        }

        public Usuario(string nombre_usuario, string clave, int rol)
        {
            this.Nombre_usuario = nombre_usuario;
            this.Clave = clave;
            this.Rol = rol;

        }

        public Usuario() {}
    }
}