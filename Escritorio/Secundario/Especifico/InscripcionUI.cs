namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class InscripcionUI : Form
    {
        public Alumno_Inscripcion Inscripcion { get; set; }

        private List<(int Id, string ApellidoYNombre)> Alumnos;
        private List<(int Id, string MateriaYComision)> Cursos;
        
        public InscripcionUI(List<(int Id, string ApellidoYNombre)> alumnos, List<(int Id, string MateriaYComision)> cursos)
        {
            InitializeComponent();

            TituloLabel.Text = "Nueva Inscripcion";
            GuardarButton.Text = "Crear";

            this.Alumnos = alumnos;
            this.Cursos = cursos;
            
            AlumnoComboBox.DataSource = ListadoNombresAlumnos();
            CursoComboBox.DataSource = ListadoNombresCursos();
        }

        public InscripcionUI(List<(int Id, string ApellidoYNombre)> docentes, List<(int Id, string MateriaYComision)> cursos, Alumno_Inscripcion inscripcionAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Inscripcion";
            GuardarButton.Text = "Modificar";

            this.Alumnos = docentes;
            this.Cursos = cursos;

            this.Inscripcion = inscripcionAModificar;

            CondicionTextBox.Text = inscripcionAModificar.Condicion;
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
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    Alumno_InscripcionDTO inscripcionModificada = EstablecerDatosInscripcionAModificar();

                    var response = await InscripcionNegocio.Update(Inscripcion.Id_inscripcion, inscripcionModificada);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        DialogResult = DialogResult.Abort;
                    }
                }
                else
                {
                    Alumno_Inscripcion nuevaInscripcion = EstablecerDatosNuevaInscripcion();

                    var response = await InscripcionNegocio.Add(nuevaInscripcion);

                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        DialogResult = DialogResult.Abort;
                    }
                }
            }
        }

        private bool ComprobarCamposRequeridos()
        {
            foreach (Control control in this.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        CampoRequerido campoRequerido = new CampoRequerido();
                        campoRequerido.CampoRequeridoLabel.Text = campoRequerido.CampoRequeridoLabel.Text.Replace("${campo}", textBox.Name.Replace("TextBox", ""));
                        campoRequerido.ShowDialog(this);

                        DialogResult = DialogResult.None;
                        return false;
                    }
                }
            }

            return true;

        }

        private Alumno_InscripcionDTO EstablecerDatosInscripcionAModificar()
        {
            int idAlumnoSeleccionado = ObtenerIdAlumnoSeleccionado();
            int idCursoSeleccionado = ObtenerIdCursoSeleccionado();

            Alumno_InscripcionDTO inscripcion = new Alumno_InscripcionDTO();

            inscripcion.Condicion = CondicionTextBox.Text;
            inscripcion.Nota = Int32.Parse(NotaTextBox.Text);
            inscripcion.Id_alumno = idAlumnoSeleccionado;
            inscripcion.Id_curso = idCursoSeleccionado;

            return inscripcion;
        }

        private Alumno_Inscripcion EstablecerDatosNuevaInscripcion()
        {
            int idAlumnoSeleccionado = ObtenerIdAlumnoSeleccionado();
            int idCursoSeleccionado = ObtenerIdCursoSeleccionado();

            Alumno_Inscripcion inscripcion = new Alumno_Inscripcion(CondicionTextBox.Text, Int32.Parse(NotaTextBox.Text), idAlumnoSeleccionado, idCursoSeleccionado);

            return inscripcion;
        }

        private int ObtenerIdAlumnoSeleccionado()
        {
            int idAlumnoSeleccionado = 0;

            foreach (var alumno in this.Alumnos)
            {
                if (alumno.ApellidoYNombre == AlumnoComboBox.SelectedValue.ToString())
                {
                    idAlumnoSeleccionado = alumno.Id;
                }
            }

            return idAlumnoSeleccionado;
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

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}