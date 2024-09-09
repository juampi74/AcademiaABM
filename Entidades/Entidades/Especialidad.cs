namespace Entidades
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Especialidad
    {

        public int Id_especialidad { get; set; }

        public string Desc_especialidad { get; set; }

        /*
        // Coleccion de Planes para la Relacion 1:N (Ver UniversidadContext.cs)
        [NotMapped]
        public List<Plan> Planes { get; set; }
        */

        public Especialidad(string desc_especialidad)
        {
            this.Desc_especialidad = desc_especialidad;
        }
    }
}