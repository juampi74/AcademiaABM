namespace Entidades
{
    using System.ComponentModel;
    
    public class CursoViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string AnioCalendario { get; set; }
        public string Cupo { get; set; }
        public string Comision { get; set; }
        public string Materia { get; set; }

    }
}