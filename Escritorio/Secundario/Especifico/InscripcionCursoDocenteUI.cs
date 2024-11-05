namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class InscripcionCursoDocenteUI : Form
    {
        public Alumno_Inscripcion Inscripcion { get; set; }

        private List<(int Id, string ApellidoYNombre)> Alumnos;
        private List<(int Id, string MateriaYComision)> Cursos;

        public string Mensaje { get; set; }

        public InscripcionCursoDocenteUI(List<(int Id, string ApellidoYNombre)> alumnos, List<(int Id, string MateriaYComision)> cursos, Alumno_Inscripcion inscripcionAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Inscripcion";
            GuardarButton.Text = "Modificar";

            this.Alumnos = alumnos;
            this.Cursos = cursos;

            this.Inscripcion = inscripcionAModificar;

            AlumnoComboBox.Enabled = false;
            CursoComboBox.Enabled = false;

            CondicionTextBox.Text = inscripcionAModificar.Condicion;
            CondicionTextBox.BackColor = Color.WhiteSmoke;
            CondicionTextBox.Enabled = false;

            NotaTextBox.Text = inscripcionAModificar.Nota.ToString();

            AlumnoComboBox.DataSource = ListadoNombresAlumnos();

            foreach (var alumno in this.Alumnos)
            {
                if (alumno.Id == inscripcionAModificar.Id_alumno)
                {
                    AlumnoComboBox.SelectedItem = alumno.ApellidoYNombre;
                }
            }

            CursoComboBox.DataSource = ListadoNombresCursos();

            foreach (var curso in this.Cursos)
            {
                if (curso.Id == inscripcionAModificar.Id_curso)
                {
                    CursoComboBox.SelectedItem = curso.MateriaYComision;
                }
            }

            NotaTextBox.TextChanged += NotaTextBox_TextChanged;
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            Alumno_InscripcionDTO inscripcionModificada = EstablecerDatosInscripcionAModificar();

            if (inscripcionModificada.Condicion != "")
            {
                var response = await InscripcionNegocio.Update(Inscripcion.Id_inscripcion, inscripcionModificada);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    DialogResult = DialogResult.OK;
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    DialogResult = DialogResult.Abort;
                }
            }
        }

        private Alumno_InscripcionDTO EstablecerDatosInscripcionAModificar()
        {
            int idAlumnoSeleccionado = this.Inscripcion.Id_alumno;
            int idCursoSeleccionado = this.Inscripcion.Id_curso;

            Alumno_InscripcionDTO inscripcion = new Alumno_InscripcionDTO();

            if (CondicionTextBox.Text != "Nota fuera de rango" && CondicionTextBox.Text != "Nota invalida")
            {
                inscripcion.Nota = int.Parse(NotaTextBox.Text);
                inscripcion.Condicion = CondicionTextBox.Text;
                inscripcion.Id_alumno = idAlumnoSeleccionado;
                inscripcion.Id_curso = idCursoSeleccionado;
            }
            else
            {
                MessageBox.Show($"Por favor, ingrese una nota válida entre 1 y 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return inscripcion;
        }

        private void CalcularCondicion()
        {
            string condicionCalculada;

            if (int.TryParse(NotaTextBox.Text, out int nota))
            {
                if (nota < 1 || nota > 10)
                {
                    condicionCalculada = "Nota fuera de rango";
                }
                else
                {
                    condicionCalculada = (nota < 4) ? "Libre" : (nota < 6) ? "Regular" : "Aprobado";
                }
            }
            else
            {
                condicionCalculada = "Nota invalida";
            }

            CondicionTextBox.Text = condicionCalculada;
        }

        private List<string> ListadoNombresAlumnos()
        {
            List<string> listadoNombresAlumnos = this.Alumnos.Select(alumno => alumno.ApellidoYNombre).ToList();

            listadoNombresAlumnos.Sort();

            return listadoNombresAlumnos;
        }
        
        private List<string> ListadoNombresCursos()
        {
            List<string> listadoNombresCursos = this.Cursos.Select(curso => curso.MateriaYComision).ToList();

            listadoNombresCursos.Sort();

            return listadoNombresCursos;
        }

        private void NotaTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcularCondicion();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}