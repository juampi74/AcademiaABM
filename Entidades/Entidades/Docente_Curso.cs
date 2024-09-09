namespace Entidades
{
    using System.ComponentModel;

    public class Docente_Curso
    {

        public int Id_dictado { get; set; }
        public string Cargo { get; set; }

        // Claves foráneas        
        public int Id_docente { get; set; }
        public int Id_curso { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Persona Docente { get; set; }

        // Evita que se muestre una columna de este atributo con AutoGenerateColumns en la DataGridView
        [Browsable(false)]
        public Curso Curso { get; set; }

        public Docente_Curso(string cargo, int id_docente, int id_curso)
        {
            this.Cargo = cargo;
            this.Id_docente = id_docente;
            this.Id_curso = id_curso;
        }
    }
}