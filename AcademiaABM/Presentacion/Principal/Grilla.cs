namespace AcademiaABM.Presentacion.Principal
{
using AcademiaABM.Negocio.Entidades;
using AcademiaABM.Negocio.Servicios;
using AcademiaABM.Presentacion;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Design;
using System.Windows.Forms;

public partial class Grilla : Form
{
    private PersonaService _personaService;
    private ComisionService _comisionService;
    private CursoService _cursoService;
    private MateriaService _materiaService;
    private PlanService _planService;
    private EspecialidadService _especialidadService;

    private string entidadListada;
    private int idPersonaActual;
    private int idComisionActual;
    private int idCursoActual;
    private int idEspecialidadActual;
    private int idPlanActual;


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

            // string connectionString = @"Server=DESKTOP-I6LRHO6\SQLEXPRESS;Initial Catalog=universidad;Integrated Security=true;Encrypt=False;Connection Timeout=5"; // Juan Pablo
            string connectionString = @"Server=DESKTOP-7MNA3TJ\SQLEXPRESS;Initial Catalog=universidad;Integrated Security=true;Encrypt=False;Connection Timeout=5"; // Nahuel
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
        else if (typeof(T) == typeof(Especialidad))
        {
            listado = _especialidadService.ObtenerTodasLasEspecialidades().Cast<T>().ToList();
            dgvSysacad.AutoGenerateColumns = true;
            dgvSysacad.DataSource = listado;

            entidadListada = "Especialidad";
        }
        else if (typeof(T) == typeof(Plan))
        {
            listado = _planService.ObtenerTodosLosPlanes().Cast<T>().ToList();
            dgvSysacad.AutoGenerateColumns = true;
            dgvSysacad.DataSource = listado;

            entidadListada = "Plan";
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

        if (_especialidadService == null)
        {
            _especialidadService = new EspecialidadService();
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
        else if (typeof(T) == typeof(Especialidad))
        {
            listado = _especialidadService.ObtenerTodasLasEspecialidades().Cast<T>().ToList();
        }

        return listado;
    }

    private T LeerEntidad<T>(int id)
    {
        object entidadADevolver = null;

        if (typeof(T) == typeof(Persona))
        {
            entidadADevolver = _personaService.ObtenerPersonaPorId(id);
        }
        else if (typeof(T) == typeof(Comision))
        {
            entidadADevolver = _comisionService.ObtenerComisionPorId(id);
        }
        else if (typeof(T) == typeof(Curso))
        {
            entidadADevolver = _cursoService.ObtenerCursoPorId(id);
        }
        else if (typeof(T) == typeof(Materia))
        {
            entidadADevolver = _materiaService.ObtenerMateriaPorId(id);
        }
        else if (typeof(T) == typeof(Plan))
        {
            entidadADevolver = _planService.ObtenerPlanPorId(id);
        }
        else if (typeof(T) == typeof(Especialidad))
        {
            entidadADevolver = _especialidadService.ObtenerEspecialidadPorId(id);
        }

        return (T)entidadADevolver;
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
        else if (typeof(T) == typeof(Especialidad))
        {
            _especialidadService.CrearEspecialidad(entidadAGuardar as Especialidad);
        }
        Listar<T>();
    }

    private void ActualizarEntidad<T>(T entidadAActualizar)
    {
        if (typeof(T) == typeof(Persona))
        {
            _personaService.ActualizarPersona(entidadAActualizar as Persona);
        }
        else if (typeof(T) == typeof(Comision))
        {
            _comisionService.ActualizarComision(entidadAActualizar as Comision);
        }
        else if (typeof(T) == typeof(Curso))
        {
            _cursoService.ActualizarCurso(entidadAActualizar as Curso);
        }
        else if (typeof(T) == typeof(Materia))
        {
            _materiaService.ActualizarMateria(entidadAActualizar as Materia);
        }
        else if (typeof(T) == typeof(Plan))
        {
            _planService.ActualizarPlan(entidadAActualizar as Plan);
        }
        else if (typeof(T) == typeof(Especialidad))
        {
            _especialidadService.ActualizarEspecialidad(entidadAActualizar as Especialidad);
        }
        Listar<T>();
    }


    private void EliminarEntidad<T>(int id)
    {
        if (typeof(T) == typeof(Persona))
        {
            _personaService.EliminarPersona(id);
        }
        else if (typeof(T) == typeof(Comision))
        {
            _comisionService.EliminarComision(id);
        }
        else if (typeof(T) == typeof(Curso))
        {
            _cursoService.EliminarCurso(id);
        }
        else if (typeof(T) == typeof(Materia))
        {
            _materiaService.EliminarMateria(id);
        }
        else if (typeof(T) == typeof(Plan))
        {
            _planService.EliminarPlan(id);
        }
        else if (typeof(T) == typeof(Especialidad))
        {
            _especialidadService.EliminarEspecialidad(id);
        }
        Listar<T>();
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
                if (entidadListada == "Persona")
                {
                    idPersonaActual = Int32.Parse(id);
                }
                else if (entidadListada == "Comision")
                {
                    idComisionActual = Int32.Parse(id);
                }
                else if (entidadListada == "Curso")
                {
                    idCursoActual = Int32.Parse(id);
                }
                else if (entidadListada == "Especialidad")
                {
                    idEspecialidadActual = Int32.Parse(id);
                }
                else if (entidadListada == "Plan")
                {
                    idPlanActual = Int32.Parse(id);
                }
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
        }
        else if (entidadListada == "Comision")
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

        }
        else if (entidadListada == "Curso")
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
        else if (entidadListada == "Especialidad")
        {

            NuevaEspecialidad nuevaEspecialidad = new NuevaEspecialidad();
            if (nuevaEspecialidad.ShowDialog(this) == DialogResult.OK)
            {
                Especialidad especialidadAGuardar = nuevaEspecialidad.Especialidad;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    CrearEntidad<Especialidad>(especialidadAGuardar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
        }
        else if (entidadListada == "Plan")
        {

            NuevoPlan nuevoPlan = new NuevoPlan();
            if (nuevoPlan.ShowDialog(this) == DialogResult.OK)
            {
                Plan planAGuardar = nuevoPlan.Plan;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    CrearEntidad<Plan>(planAGuardar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
        }

    }


    private void tsbEditar_Click(object sender, EventArgs e)
    {
        if (entidadListada == "Persona")
        {
            Persona personaAEditar = LeerEntidad<Persona>(idPersonaActual);
            EditarPersona editarPersona = new EditarPersona(personaAEditar);

            if (editarPersona.ShowDialog(this) == DialogResult.OK)
            {
                Persona personaAActualizar = editarPersona.PersonaAEditar;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarEntidad(personaAActualizar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
        }


        else if (entidadListada == "Comision")
        {

            Comision comisionAEditar = LeerEntidad<Comision>(idComisionActual);

            EditarComision editarComision = new EditarComision(comisionAEditar);

            if (editarComision.ShowDialog(this) == DialogResult.OK)
            {
                Comision comisionAActualizar = editarComision.ComisionAEditar;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarEntidad(comisionAActualizar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }

        }
        else if (entidadListada == "Curso")
        {
            Curso cursoAEditar = LeerEntidad<Curso>(idCursoActual);
            EditarCurso editarCurso = new EditarCurso(cursoAEditar);

            if (editarCurso.ShowDialog(this) == DialogResult.OK)
            {
                Curso cursoAActualizar = editarCurso.CursoAEditar;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarEntidad(cursoAActualizar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
        }
        else if (entidadListada == "Especialidad")
        {

            Especialidad especialidadAEditar = LeerEntidad<Especialidad>(idEspecialidadActual);

            EditarEspecialidad editarEspecialidad = new EditarEspecialidad(especialidadAEditar);

            if (editarEspecialidad.ShowDialog(this) == DialogResult.OK)
            {
                Especialidad especialidadAActualizar = editarEspecialidad.EspecialidadAEditar;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarEntidad(especialidadAActualizar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }

        }
        else if (entidadListada == "Plan")
        {

            Plan planAEditar = LeerEntidad<Plan>(idPlanActual);

            EditarPlan editarPlan = new EditarPlan(planAEditar);

            if (editarPlan.ShowDialog(this) == DialogResult.OK)
            {
                Plan planAActualizar = editarPlan.PlanAEditar;
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarEntidad(planAActualizar);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }

        }
    }

    private void tsbEliminar_Click(object sender, EventArgs e)
    {
        

            if (entidadListada == "Persona")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    EliminarEntidad<Persona>(idPersonaActual);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
            else if (entidadListada == "Comision")
            {

                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    EliminarEntidad<Comision>(idComisionActual);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }

            }
            else if (entidadListada == "Curso")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    EliminarEntidad<Curso>(idCursoActual);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
            }
            else if (entidadListada == "Especialidad")
            {

                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    EliminarEntidad<Especialidad>(idEspecialidadActual);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }

            }
            else if (entidadListada == "Plan")
            {

                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    EliminarEntidad<Plan>(idPlanActual);
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }

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
    private void btnMostrarEspecialidades_Click(object sender, EventArgs e)
    {
        Listar<Especialidad>();
    }
    private void btnMostrarPlanes_Click(object sender, EventArgs e)
    {
        Listar<Plan>();
    }

}
}