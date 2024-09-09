namespace Entidades
{
    using System.ComponentModel;

    public class Alumno_Inscripcion
    {

        public int Id_inscripcion { get; set; }
        public string Condicion { get; set; }
        public int Nota { get; set; }

        // Claves foráneas        
        public int Id_alumno { get; set; }
        public int Id_curso { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Persona Alumno { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Curso Curso { get; set; }

        public Alumno_Inscripcion(string condicion, int nota, int id_alumno, int id_curso)
        {
            this.Condicion = condicion;
            this.Nota = nota;
            this.Id_alumno = id_alumno;
            this.Id_curso = id_curso;
        }
    }
}
