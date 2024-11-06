namespace Entidades
{
    public class Alumno_Inscripcion
    {
        public int Id_inscripcion { get; set; }
        public string Condicion { get; set; }
        public int Nota { get; set; }
        public int Id_alumno { get; set; }
        public int Id_curso { get; set; }
        public Persona Alumno { get; set; }
        public Curso Curso { get; set; }

        public Alumno_Inscripcion(string condicion, int nota, int id_alumno, int id_curso)
        {
            this.Condicion = condicion;
            this.Nota = nota;
            this.Id_alumno = id_alumno;
            this.Id_curso = id_curso;
        }

        public Alumno_Inscripcion() {}
    }
}