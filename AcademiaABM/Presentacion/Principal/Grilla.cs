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
        private PersonaService _personaService;
        private ComisionService _comisionService;
        private CursoService _cursoService;

        private String entidadListada;
        private int idActual;

        public Grilla()
        {
            InitializeComponent();
            Listar<Persona>();
        }

        public void Listar<T>()
        {
            // Si ya está inicializado, reutiliza el existente (Ver método InitializeService())
            InitializeService();

            List<T> listado = null;
            if (typeof(T) == typeof(Persona))
            {
                listado = _personaService.ObtenerTodasLasPersonas().Cast<T>().ToList();
                dgvSysacad.AutoGenerateColumns = true;
                dgvSysacad.DataSource = listado;

                entidadListada = "Persona";
            }
            else if (typeof(T) == typeof(Comision))
            {
                listado = _comisionService.ObtenerTodasLasComisiones().Cast<T>().ToList();
                dgvSysacad.AutoGenerateColumns = true;
                dgvSysacad.DataSource = listado;

                entidadListada = "Comision";
            }
            else if (typeof(T) == typeof(Curso))
            {
                //listado = _cursoService.ObtenerTodosLosCursos().Cast<T>().ToList();
                //dgvSysacad.AutoGenerateColumns = true;
                //dgvSysacad.DataSource = listado;

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
                

                entidadListada = "Curso";
            }

            SeleccionarPrimeraFila();
        }

        private void InitializeService()
        {
            if (_personaService == null)
            {
                _personaService = new PersonaService();
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

        private Persona LeerPersona(int id)
        {
            return _personaService.ObtenerPersonaPorId(id);
        }
        
        /*
        private void CrearPersona(Persona personaAGuardar)
        {
            _personaService.CrearPersona(personaAGuardar);
            Listar<Persona>();
        }

        private void CrearComision(Comision comisionAGuardar)
        {
            _comisionService.CrearComision(comisionAGuardar);
            Listar<Comision>();
        }
        */

        private void CrearEntidad<T>(T entidadAGuardar)
        {
            if (typeof(T) == typeof(Persona))
            {
                _personaService.CrearPersona(entidadAGuardar as Persona);
            }
            else if (typeof(T) == typeof(Comision))
            {
                _comisionService.CrearComision(entidadAGuardar as Comision);
            }
            else if (typeof(T) == typeof(Curso))
            {
                _cursoService.CrearCurso(entidadAGuardar as Curso);
            }
            Listar<T>();
        }
        private void ActualizarPersona(Persona personaAGuardar)
        {
            _personaService.ActualizarPersona(personaAGuardar);
            Listar<Persona>();
        }

        private void EliminarPersona(int id)
        {
            _personaService.EliminarPersona(id);
            Listar<Persona>();
        }

        private void OrdenarPersonasAscendente()
        {
            var personasOrdenadosAscendente = _personaService.OrdenarPersonasAscendente();
            dgvSysacad.DataSource = personasOrdenadosAscendente;
        }

        private void OrdenarPersonasDescendente()
        {
            var personasOrdenadosDescendente = _personaService.OrdenarPersonasDescendente();
            dgvSysacad.DataSource = personasOrdenadosDescendente;
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
                try
                {
                    idActual = Int32.Parse(id);
                }
                catch
                {
                    MessageBox.Show("Seleccione otra fila!");
                }
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            if (entidadListada == "Persona")
            {
                NuevaPersona nuevaPersona = new NuevaPersona();
                if (nuevaPersona.ShowDialog(this) == DialogResult.OK)
                {
                    Persona personaAGuardar = nuevaPersona.Persona;
                    ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                    if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                    {
                        CrearEntidad<Persona>(personaAGuardar);
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                }
            } else if (entidadListada == "Comision")
            {                
                NuevaComision nuevaComision = new NuevaComision();
                if (nuevaComision.ShowDialog(this) == DialogResult.OK)
                {
                    Comision comisionAGuardar = nuevaComision.Comision;
                    ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                    if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                    {
                        CrearEntidad<Comision>(comisionAGuardar);
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                }

            } else if (entidadListada == "Curso")
            {
                NuevoCurso nuevoCurso = new NuevoCurso();
                if (nuevoCurso.ShowDialog(this) == DialogResult.OK)
                {
                    Curso cursoAGuardar = nuevoCurso.Curso;
                    ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                    if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                    {
                        CrearEntidad<Curso>(cursoAGuardar);
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            Persona personaAEditar = LeerPersona(idActual);
            EditarPersona editarPersona = new EditarPersona(personaAEditar);
            if (editarPersona.ShowDialog(this) == DialogResult.OK)
            {
                Persona personaAGuardar = editarPersona.PersonaAEditar;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarPersona(personaAGuardar);
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
                EliminarPersona(idActual);
                OperacionExitosa operacionExitosa = new OperacionExitosa();
                operacionExitosa.ShowDialog(this);
            }
        }

        private void tsbOrdenarAscendente_Click(object sender, EventArgs e)
        {
            OrdenarPersonasAscendente();
        }

        private void tsbOrdenarDescendente_Click(object sender, EventArgs e)
        {
            OrdenarPersonasDescendente();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar<Persona>();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrarPersonas_Click(object sender, EventArgs e)
        {
            Listar<Persona>();
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
