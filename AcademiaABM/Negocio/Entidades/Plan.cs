namespace AcademiaABM.Negocio.Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Plan
    {
        public int Id_plan { get; set; }
        public string Desc_plan { get; set; }

        // Clave foránea
        public int Id_especialidad { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Especialidad Especialidad { get; set; }

        // Coleccion de Personas para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Persona> Personas { get; set; }

        // Coleccion de Comisiones para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Comision> Comisiones { get; set; }

        // Coleccion de Materias para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Materia> Materias { get; set; }

        public Plan(string desc_plan, int id_especialidad)
        {
            this.Desc_plan = desc_plan;
            this.Id_especialidad = id_especialidad;
        }
    }
}