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

        // Clave foránea
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
    }
}