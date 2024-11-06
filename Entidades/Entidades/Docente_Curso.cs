namespace Entidades
{
    public class Docente_Curso
    {
        public int Id_dictado { get; set; }
        public string Cargo { get; set; }
        public int Id_docente { get; set; }
        public int Id_curso { get; set; }
        public Persona Docente { get; set; }
        public Curso Curso { get; set; }

        public Docente_Curso(string cargo, int id_docente, int id_curso)
        {
            this.Cargo = cargo;
            this.Id_docente = id_docente;
            this.Id_curso = id_curso;
        }

        public Docente_Curso() {}
    }
}