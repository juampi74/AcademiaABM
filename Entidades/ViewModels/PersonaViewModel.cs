namespace Entidades
{
    using System.ComponentModel;
    
    public class PersonaViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string ApellidoYNombre { get; set; }
        public string FechaNacimiento { get; set; }
        public string Legajo { get; set; }
        public string Tipo { get; set; }
        public string Plan { get; set; }
    }
}