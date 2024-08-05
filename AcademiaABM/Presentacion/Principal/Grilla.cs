namespace AcademiaABM.Presentacion.Principal
{
    using AcademiaABM.Negocio.Entidades;
    using AcademiaABM.Negocio.Servicios;
    using Microsoft.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class Grilla : Form
    {
        private AlumnoService _alumnoService;
        private ComisionService _comisionService;
        private CursoService _cursoService;

        private int idActual;

        public Grilla()
        {
            InitializeComponent();
            Listar<Alumno>();
        }

        public void Listar<T>()
        {
            // Si ya está inicializado, reutiliza el existente (Ver método InitializeService())
            InitializeService();

            List<T> listado = null;
            if (typeof(T) == typeof(Alumno))
            {
                listado = _alumnoService.ObtenerTodosLosAlumnos().Cast<T>().ToList();
                dgvSysacad.AutoGenerateColumns = true;
                dgvSysacad.DataSource = listado;
            }
            else if (typeof(T) == typeof(Comision))
            {
                listado = _comisionService.ObtenerTodasLasComisiones().Cast<T>().ToList();
                dgvSysacad.AutoGenerateColumns = true;
                dgvSysacad.DataSource = listado;
            }
            else if (typeof(T) == typeof(Curso))
            {
                // List<Curso> listadoCursos = _cursoService.ObtenerTodosLosCursos().ToList();
                
                
                // Prueba SQL Nativo - JOIN Cursos y Comisiones
                // Habría que sacarlo de la vista después
                
                // Conectar a la base de datos
                string connectionString = @"Server=DESKTOP-I6LRHO6\SQLEXPRESS;Initial Catalog=universidad;Integrated Security=true;Encrypt=False;Connection Timeout=5";
                SqlConnection connection = new SqlConnection(connectionString);

                // Crear la consulta SQL
                string query = @"
                SELECT 
                    cu.Id_curso, 
                    cu.Anio_calendario, 
                    cu.Cupo, 
                    co.Desc_comision AS Comision
                FROM 
                    Cursos cu
                JOIN 
                    Comisiones co ON cu.Id_comision = co.Id_comision
                WHERE
                    cu.Id_curso IS NOT NULL
                ";

                // Crear un adaptador de datos
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                // Crear un conjunto de datos
                DataSet dataSet = new DataSet();

                // Rellenar el conjunto de datos
                adapter.Fill(dataSet);

                // Asignar el conjunto de datos al DataGridView
                dgvSysacad.DataSource = dataSet.Tables[0];
            }

            // dgvSysacad.AutoGenerateColumns = true;
            // dgvSysacad.DataSource = listado;
            SeleccionarPrimeraFila();
        }

        private void InitializeService()
        {
            if (_alumnoService == null)
            {
                _alumnoService = new AlumnoService();
            }

            if (_comisionService == null)
            {
                _comisionService = new ComisionService();
            }

            if (_cursoService == null)
            {
                _cursoService = new CursoService();
            }
        }

        private void SeleccionarPrimeraFila()
        {
            if (dgvSysacad.Rows.Count > 0)
            {
                dgvSysacad.Rows[0].Selected = true;
            }
        }

        private Alumno LeerAlumno(int id)
        {
            return _alumnoService.ObtenerAlumnoPorId(id);
        }

        private void CrearAlumno(Alumno alumnoAGuardar)
        {
            _alumnoService.CrearAlumno(alumnoAGuardar);
            Listar<Alumno>();
        }

        private void ActualizarAlumno(Alumno alumnoAGuardar)
        {
            _alumnoService.ActualizarAlumno(alumnoAGuardar);
            Listar<Alumno>();
        }

        private void EliminarAlumno(int id)
        {
            _alumnoService.EliminarAlumno(id);
            Listar<Alumno>();
        }

        private void OrdenarAlumnosAscendente()
        {
            var alumnosOrdenadosAscendente = _alumnoService.OrdenarAlumnosAscendente();
            dgvSysacad.DataSource = alumnosOrdenadosAscendente;
        }

        private void OrdenarAlumnosDescendente()
        {
            var alumnosOrdenadosDescendente = _alumnoService.OrdenarAlumnosDescendente();
            dgvSysacad.DataSource = alumnosOrdenadosDescendente;
        }

        private void dgvSysacad_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSysacad.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSysacad.SelectedRows[0];
                string id = row.Cells[0].Value.ToString();
                
                // Con la Consulta SQL hecha a mano, te devuelve la última fila
                // con el asterisco como "número" de fila y todos los campos
                // vacíos. Para que no falle el programa, hago un trycatch.
                try { 
                    idActual = Int32.Parse(id);
                } catch
                {
                    MessageBox.Show("Seleccione otra fila!");
                }
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
            Alumno alumnoAEditar = LeerAlumno(idActual);
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
                EliminarAlumno(idActual);
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
            Listar<Alumno>();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrarAlumnos_Click(object sender, EventArgs e)
        {
            Listar<Alumno>();
        }

        private void btnMostrarComisiones_Click(object sender, EventArgs e)
        {
            Listar<Comision>();
        }

        private void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            Listar<Curso>();
        }
    }
}
