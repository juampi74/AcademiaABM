namespace Entidades
{
    using System.ComponentModel;
    
    public class MateriaViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public string HorasSemanales { get; set; }
        public string HorasTotales { get; set; }
        public string Plan { get; set; }
    }
}
