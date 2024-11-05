namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class InscripcionAlumnoUI : Form
    {
        private int Id_alumno; 
        private List<(int Id, string MateriaYComision)> Cursos;

        public string Mensaje { get; set; }

        public InscripcionAlumnoUI(int id_alumno, List<(int Id, string MateriaYComision)> cursos)
        {
            InitializeComponent();

            TituloLabel.Text = "Nueva Inscripcion";
            GuardarButton.Text = "Crear";

            this.Id_alumno = id_alumno;
            this.Cursos = cursos;

            CursoComboBox.DataSource = ListadoNombresCursos();
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            Alumno_Inscripcion nuevaInscripcion = EstablecerDatosNuevaInscripcion();

            var response = await InscripcionNegocio.Add(nuevaInscripcion);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                this.Mensaje = (await response.Content.ReadAsStringAsync()).Trim('"');
                DialogResult = DialogResult.Abort;
            }
        }

        private Alumno_Inscripcion EstablecerDatosNuevaInscripcion()
        {
            int idAlumnoSeleccionado = this.Id_alumno;
            int idCursoSeleccionado = ObtenerIdCursoSeleccionado();

            Alumno_Inscripcion inscripcion = new Alumno_Inscripcion("Inscripto", 0, idAlumnoSeleccionado, idCursoSeleccionado);

            return inscripcion;
        }

        private int ObtenerIdCursoSeleccionado()
        {
            int idCursoSeleccionado = 0;

            foreach (var curso in this.Cursos)
            {
                if (curso.MateriaYComision == CursoComboBox.SelectedValue.ToString())
                {
                    idCursoSeleccionado = curso.Id;
                }
            }

            return idCursoSeleccionado;
        }

        private List<string> ListadoNombresCursos()
        {
            List<string> listadoNombresCursos = this.Cursos.Select(curso => curso.MateriaYComision).ToList();

            listadoNombresCursos.Sort();

            return listadoNombresCursos;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}