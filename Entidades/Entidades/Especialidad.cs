namespace Entidades
{
    public class Especialidad
    {
        public int Id_especialidad { get; set; }
        public string Desc_especialidad { get; set; }

        public Especialidad(string desc_especialidad)
        {
            this.Desc_especialidad = desc_especialidad;
        }

        public Especialidad() {}
    }
}