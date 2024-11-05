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

        public string Mensaje { get; set; }

        private bool _suspendComboBoxEvent = false;

        public InscripcionUI(List<(int Id, string ApellidoYNombre)> alumnos)
        {
            InitializeComponent();

            TituloLabel.Text = "Nueva Inscripcion";
            GuardarButton.Text = "Crear";

            NotaLabel.Visible = false;
            NotaTextBox.Visible = false;
            CondicionLabel.Visible = false;
            CondicionTextBox.Visible = false;

            this.Alumnos = alumnos;

            AlumnoComboBox.DataSource = ListadoNombresAlumnos();

            this.Inscripcion = new Alumno_Inscripcion();

            Inscripcion.Id_alumno = ObtenerIdAlumnoSeleccionado();

            AlumnoComboBox.SelectedIndexChanged += AlumnoComboBox_SelectedIndexChanged;

            this.Load += async (sender, e) => await CargarCursosAsync();
        }

        public InscripcionUI(List<(int Id, string ApellidoYNombre)> alumnos, List<(int Id, string MateriaYComision)> cursos, Alumno_Inscripcion inscripcionAModificar)
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

            CursoComboBox.DataSource = ListadoNombresCursosModificacion();

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
            if (GuardarButton.Text == "Modificar")
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
                    this.Mensaje = (await response.Content.ReadAsStringAsync()).Trim('"');
                    DialogResult = DialogResult.Abort;
                }
            }
        }

        private Alumno_InscripcionDTO EstablecerDatosInscripcionAModificar()
        {
            int idAlumnoSeleccionado = ObtenerIdAlumnoSeleccionado();
            int idCursoSeleccionado = ObtenerIdCursoSeleccionado();

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

        private Alumno_Inscripcion EstablecerDatosNuevaInscripcion()
        {
            int idAlumnoSeleccionado = ObtenerIdAlumnoSeleccionado();
            int idCursoSeleccionado = ObtenerIdCursoSeleccionado();

            Alumno_Inscripcion inscripcion = new Alumno_Inscripcion("Inscripto", 0, idAlumnoSeleccionado, idCursoSeleccionado);

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

        private async Task CargarCursosAsync()
        {
            CursoComboBox.DataSource = await ListadoNombresCursosCreacion();
        }

        private async Task<List<string>> ListadoNombresCursosCreacion()
        {
            var cursos_alumno = (List<Curso>)await CursoNegocio.GetCursosParaPersona(Inscripcion.Id_alumno.ToString());

            this.Cursos = cursos_alumno.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

            if (cursos_alumno.Any())
            {
                cursos_alumno = cursos_alumno.OrderBy(cur => cur.Materia.Desc_materia).ThenBy(cur => cur.Comision.Desc_comision).ToList();
            }

            return cursos_alumno.Select(curso => (curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();
        }

        private List<string> ListadoNombresCursosModificacion()
        {
            List<string> listadoNombresCursos = this.Cursos.Select(curso => curso.MateriaYComision).ToList();

            listadoNombresCursos.Sort();

            return listadoNombresCursos;
        }

        private async void AlumnoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suspendComboBoxEvent) return;

            _suspendComboBoxEvent = true;

            Inscripcion.Id_alumno = ObtenerIdAlumnoSeleccionado();

            CursoComboBox.DataSource = await ListadoNombresCursosCreacion();

            _suspendComboBoxEvent = false;
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