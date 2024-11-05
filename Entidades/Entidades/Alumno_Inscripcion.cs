namespace Entidades
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Alumno_Inscripcion
    {

        public int Id_inscripcion { get; set; }

        [Required(ErrorMessage = "El campo Condicion es obligatorio.")]
        public string Condicion { get; set; }

        [Required(ErrorMessage = "El campo Nota es obligatorio.")]
        public int Nota { get; set; }

        // Claves foráneas
        [Required(ErrorMessage = "El campo Alumno es obligatorio.")]
        public int Id_alumno { get; set; }

        [Required(ErrorMessage = "El campo Curso es obligatorio.")]
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

        public Alumno_Inscripcion() {}
    }
}