using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiaABM.Negocio.Entidades
{
    public class Comision
    {
        private int id_comision;
        private string desc_comision;
        private int anio_especialidad;
        // Agregar id_plan

        // Coleccion de Cursos para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Curso> cursos { get; set; }

        public Comision(int id_comision, string desc_comision, int anio_especialidad)
        {
            this.id_comision = id_comision;
            this.desc_comision = desc_comision;
            this.anio_especialidad = anio_especialidad;
        }

        public int Id_comision
        {
            get { return id_comision; }
            set { id_comision = value; }
        }
        public string Desc_comision
        {
            get { return desc_comision; }
            set { desc_comision = value; }
        }
        public int Anio_especialidad
        {
            get { return anio_especialidad; }
            set { anio_especialidad = value; }
        }
        public List<Curso> Cursos
        {
            get { return cursos; }
            set { cursos = value; }
        }
    }
}
