namespace Entidades
{
    public class Plan
    {
        public int Id_plan { get; set; }
        public string Desc_plan { get; set; }
        public int Id_especialidad { get; set; }
        public Especialidad Especialidad { get; set; }

        public Plan(string desc_plan, int id_especialidad)
        {
            this.Desc_plan = desc_plan;
            this.Id_especialidad = id_especialidad;
        }

        public Plan() {}
    }
}