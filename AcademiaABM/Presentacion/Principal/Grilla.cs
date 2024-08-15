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
        private MateriaService _materiaService;
        private PlanService _planService;

        private string entidadListada;
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

                // Prueba SQL Nativo - JOIN Cursos, Comisiones y Materias
                // Habría que sacarlo de la vista después

                // Conectar a la base de datos
                
                string connectionString = @"Server=DESKTOP-I6LRHO6\SQLEXPRESS;Initial Catalog=universidad;Integrated Security=true;Encrypt=False;Connection Timeout=5";
                SqlConnection connection = new SqlConnection(connectionString);

                // Crear la consulta SQL
                string query = @"
                SELECT 
                    cur.Id_curso, 
                    cur.Anio_calendario, 
                    cur.Cupo, 
                    com.Desc_comision AS Comision,
                    mat.Desc_materia AS Materia
                FROM 
                    Cursos cur
                JOIN 
                    Comisiones com ON cur.Id_comision = com.Id_comision
                JOIN 
                    Materias mat ON cur.Id_materia = mat.Id_materia
                WHERE
                    cur.Id_curso IS NOT NULL AND
                    mat.Id_materia IS NOT NULL; 
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
            else if (typeof(T) == typeof(Materia))
            {
                listado = _materiaService.ObtenerTodasLasMaterias().Cast<T>().ToList();
                dgvSysacad.AutoGenerateColumns = true;
                dgvSysacad.DataSource = listado;

                entidadListada = "Materia";
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

            if (_materiaService == null)
            {
                _materiaService = new MateriaService();
            }

            if (_planService == null)
            {
                _planService = new PlanService();
            }
        }

        private void SeleccionarPrimeraFila()
        {
            if (dgvSysacad.Rows.Count > 0)
            {
                dgvSysacad.Rows[0].Selected = true;
            }
        }

        private List<T> LeerEntidades<T>()
        {
            List<T> listado = null;

            if (typeof(T) == typeof(Persona))
            {
                listado = _personaService.ObtenerTodasLasPersonas().Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Comision))
            {
                listado = _comisionService.ObtenerTodasLasComisiones().Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Curso))
            {
                listado = _cursoService.ObtenerTodosLosCursos().Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Materia))
            {
                listado = _materiaService.ObtenerTodasLasMaterias().Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Plan))
            {
                listado = _planService.ObtenerTodosLosPlanes().Cast<T>().ToList();
            }

            return listado;
        }

        private Persona LeerPersona(int id)
        {
            return _personaService.ObtenerPersonaPorId(id);
        }

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
            else if (typeof(T) == typeof(Materia))
            {
                _materiaService.CrearMateria(entidadAGuardar as Materia);
            }
            else if (typeof(T) == typeof(Plan))
            {
                _planService.CrearPlan(entidadAGuardar as Plan);
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
                List<Plan> planes = LeerEntidades<Plan>().Cast<Plan>().ToList();
                
                List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan)).ToList();
                
                NuevaPersona nuevaPersona = new NuevaPersona(opcionesPlan);
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
                List<Plan> planes = LeerEntidades<Plan>().Cast<Plan>().ToList();

                List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan)).ToList();

                NuevaComision nuevaComision = new NuevaComision(opcionesPlan);
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
                List<Comision> comisiones = LeerEntidades<Comision>().Cast<Comision>().ToList();
                List<Materia> materias = LeerEntidades<Materia>().Cast<Materia>().ToList();

                List<(int Id, string Descripcion)> opcionesComision = comisiones.Select(comision => (comision.Id_comision, comision.Desc_comision)).ToList();
                List<(int Id, string Descripcion)> opcionesMateria = materias.Select(materia => (materia.Id_materia, materia.Desc_materia)).ToList();

                NuevoCurso nuevoCurso = new NuevoCurso(opcionesComision, opcionesMateria);
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
