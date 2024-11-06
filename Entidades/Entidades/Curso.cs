namespace Entidades
{
    public class Curso
    {
        public int Id_curso { get; set; }
        public int Anio_calendario { get; set; }
        public int Cupo { get; set; }
        public int Id_comision { get; set; }
        public int Id_materia { get; set; }
        public Comision Comision { get; set; }
        public Materia Materia { get; set; }

        public Curso(int anio_calendario, int cupo, int id_comision, int id_materia)
        {
            this.Anio_calendario = anio_calendario;
            this.Cupo = cupo;
            this.Id_comision = id_comision;
            this.Id_materia = id_materia;
        }

        public Curso() {}
    }
}