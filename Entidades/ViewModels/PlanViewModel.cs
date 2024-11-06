namespace Entidades
{
    using System.ComponentModel;
    
    public class PlanViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public string Especialidad { get; set; }
    }
}