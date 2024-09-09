namespace Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Materia
    {
        public int Id_materia { get; set; }
        public string Desc_materia { get; set; }
        public int Hs_semanales { get; set; }
        public int Hs_totales { get; set; }

        // Clave foránea
        public int Id_plan { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Plan Plan { get; set; }

        /*
        [JsonIgnore]
        // Coleccion de Cursos para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Curso> Cursos { get; set; }
        */

        public Materia(string desc_materia, int hs_semanales, int hs_totales, int id_plan)
        {
            this.Desc_materia = desc_materia;
            this.Hs_semanales = hs_semanales;
            this.Hs_totales = hs_totales;
            this.Id_plan = id_plan;
        }
    }
}
