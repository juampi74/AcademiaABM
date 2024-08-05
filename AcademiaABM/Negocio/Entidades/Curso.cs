namespace AcademiaABM.Negocio.Entidades
{
    public class Curso
    {
        private int id_curso;
        // Agregar id_materia
        private int anio_calendario;
        private int cupo;

        // Clave foránea
        public int id_comision;
        
        public Comision comision;

        public Curso(int id_curso, int anio_calendario, int cupo, int id_comision)
        {
            this.id_curso = id_curso;
            this.anio_calendario = anio_calendario;
            this.cupo = cupo;
            this.id_comision = id_comision;
        }

        public int Id_curso
        {
            get { return id_curso; }
            set { id_curso = value; }
        }
        public int Anio_calendario
        {
            get { return anio_calendario; }
            set { anio_calendario = value; }
        }
        public int Cupo
        {
            get { return cupo; }
            set { cupo = value; }
        }
        public int Id_comision
        {
            get { return id_comision; }
            set { id_comision = value; }
        }
        public Comision Comision
        {
            get { return comision; }
            set { comision = value; }
        }
    }
}

