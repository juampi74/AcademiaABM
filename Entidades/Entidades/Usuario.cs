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

        [Required(ErrorMessage = "El campo Habilitado es obligatorio.")]
        public int Habilitado { get; set; }

        [Required(ErrorMessage = "El campo Cambia Clave es obligatorio.")]
        public int Cambia_clave { get; set; }

        // Clave foránea
        [Required(ErrorMessage = "El campo Persona es obligatorio.")]
        public int Id_persona { get; set; }


        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Persona Persona { get; set; }

        public Usuario(string nombre_usuario, string clave, int habilitado, int cambia_clave, int id_persona)
        {
            this.Nombre_usuario = nombre_usuario;
            this.Clave = clave;
            this.Habilitado = habilitado;
            this.Cambia_clave = cambia_clave;
            this.Id_persona = id_persona;

        }

        public Usuario() {}
    }
}