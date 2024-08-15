namespace AcademiaABM.Negocio.Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comision
    {
        public int Id_comision { get; set; }
        public string Desc_comision { get; set; }
        public int Anio_especialidad { get; set; }

        // Clave foránea
        public int Id_plan { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Plan Plan { get; set; }

        // Coleccion de Cursos para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Curso> Cursos { get; set; }

        public Comision(string desc_comision, int anio_especialidad, int id_plan)
        {
            this.Desc_comision = desc_comision;
            this.Anio_especialidad = anio_especialidad;
            this.Id_plan = id_plan;
        }
    }
}
