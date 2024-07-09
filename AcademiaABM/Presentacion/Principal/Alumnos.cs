namespace AcademiaABM.Presentacion.Principal
{
    using AcademiaABM.Negocio.Entidades;
    using AcademiaABM.Negocio.Servicios;

    public partial class Alumnos : Form
    {
        private AlumnoService _alumnoService;

        private int idAlumnoActual;

        public Alumnos()
        {
            InitializeComponent();
            Listar();
        }

        public void Listar()
        {
            // Si ya está inicializado, reutiliza el existente (Ver método InitializeService())
            InitializeService();

            List<Alumno> listadoAlumnos = _alumnoService.ObtenerTodosLosAlumnos();
            dgvAlumnos.AutoGenerateColumns = true;
            dgvAlumnos.DataSource = listadoAlumnos;
            SeleccionarPrimeraFila();
        }

        private void InitializeService()
        {
            if (_alumnoService == null)
            {
                _alumnoService = new AlumnoService();
            }
        }

        private void SeleccionarPrimeraFila()
        {
            if (dgvAlumnos.Rows.Count > 0)
            {
                dgvAlumnos.Rows[0].Selected = true;
            }
        }

        private Alumno LeerAlumno(int id)
        {
            return _alumnoService.ObtenerAlumnoPorId(id);
        }

        private void CrearAlumno(Alumno alumnoAGuardar)
        {
            _alumnoService.CrearAlumno(alumnoAGuardar);
            Listar();
        }

        private void ActualizarAlumno(Alumno alumnoAGuardar)
        {
            _alumnoService.ActualizarAlumno(alumnoAGuardar);
            Listar();
        }

        private void EliminarAlumno(int id)
        {
            _alumnoService.EliminarAlumno(id);
            Listar();
        }

        private void OrdenarAlumnosAscendente()
        {
            var alumnosOrdenadosAscendente = _alumnoService.OrdenarAlumnosAscendente();
            dgvAlumnos.DataSource = alumnosOrdenadosAscendente;
        }

        private void OrdenarAlumnosDescendente()
        {
            var alumnosOrdenadosDescendente = _alumnoService.OrdenarAlumnosDescendente();
            dgvAlumnos.DataSource = alumnosOrdenadosDescendente;
        }

        private void dgvAlumnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAlumnos.SelectedRows[0];
                string idAlumno = row.Cells[0].Value.ToString();
                idAlumnoActual = Int32.Parse(idAlumno);
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            NuevoAlumno nuevoAlumno = new NuevoAlumno();
            if (nuevoAlumno.ShowDialog(this) == DialogResult.OK)
            {
                Alumno alumnoAGuardar = nuevoAlumno.Alumno;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    CrearAlumno(alumnoAGuardar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            Alumno alumnoAEditar = LeerAlumno(idAlumnoActual);
            EditarAlumno editarAlumno = new EditarAlumno(alumnoAEditar);
            if (editarAlumno.ShowDialog(this) == DialogResult.OK)
            {
                Alumno alumnoAGuardar = editarAlumno.AlumnoAEditar;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarAlumno(alumnoAGuardar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
            if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
            {
                EliminarAlumno(idAlumnoActual);
                OperacionExitosa operacionExitosa = new OperacionExitosa();
                operacionExitosa.ShowDialog(this);
            }
        }

        private void tsbOrdenarAscendente_Click(object sender, EventArgs e)
        {
            OrdenarAlumnosAscendente();
        }

        private void tsbOrdenarDescendente_Click(object sender, EventArgs e)
        {
            OrdenarAlumnosDescendente();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
