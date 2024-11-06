namespace Entidades
{
    using System.ComponentModel;
    
    public class ComisionViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        
        public string Descripcion { get; set; }
        public int AnioEspecialidad { get; set; }
        public string Plan { get; set; }

    }
}