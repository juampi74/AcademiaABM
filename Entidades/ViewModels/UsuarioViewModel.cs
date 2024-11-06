namespace Entidades
{
    using System.ComponentModel;
    
    public class UsuarioViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public string Persona { get; set; }
    }
}