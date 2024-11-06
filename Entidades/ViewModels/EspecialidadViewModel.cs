namespace Entidades
{
    using System.ComponentModel;
    
    public class EspecialidadViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Descripcion { get; set; }
    }
}