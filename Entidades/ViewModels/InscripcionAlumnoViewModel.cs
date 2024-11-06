namespace Entidades
{
    using System.ComponentModel;
    
    public class InscripcionAlumnoViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Condicion { get; set; }
        public string Nota { get; set; }
        public string Curso { get; set; }
    }
}