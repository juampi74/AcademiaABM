namespace Entidades
{
    public class Comision
    {
        public int Id_comision { get; set; }
        public string Desc_comision { get; set; }
        public int Anio_especialidad { get; set; }
        public int Id_plan { get; set; }
        public Plan Plan { get; set; }

        public Comision(string desc_comision, int anio_especialidad, int id_plan)
        {
            this.Desc_comision = desc_comision;
            this.Anio_especialidad = anio_especialidad;
            this.Id_plan = id_plan;
        }

        public Comision() { }
    }
}