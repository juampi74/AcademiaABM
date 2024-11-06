namespace Entidades
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public string Nombre_usuario { get; set; }
        public string Clave { get; set; }
        public int Rol { get; set; }
        public int? Id_persona { get; set; }
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