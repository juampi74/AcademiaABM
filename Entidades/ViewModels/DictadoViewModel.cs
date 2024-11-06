namespace Entidades
{
    using System.ComponentModel;
    
    public class DictadoViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Cargo { get; set; }
        public string Docente { get; set; }
        public string Curso { get; set; }
    }
}