namespace Entidades
{
    public class Materia
    {
        public int Id_materia { get; set; }
        public string Desc_materia { get; set; }
        public int Hs_semanales { get; set; }
        public int Hs_totales { get; set; }
        public int Id_plan { get; set; }
        public Plan Plan { get; set; }

        public Materia(string desc_materia, int hs_semanales, int hs_totales, int id_plan)
        {
            this.Desc_materia = desc_materia;
            this.Hs_semanales = hs_semanales;
            this.Hs_totales = hs_totales;
            this.Id_plan = id_plan;
        }

        public Materia() { }
    }
}
