namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class Grilla : Form
    {
        private Usuario usuarioAutenticado;

        private string entidadListada;

        private Task<IEnumerable<Comision>>? listadoComisiones;
        private Task<IEnumerable<Curso>>? listadoCursos;
        private Task<IEnumerable<Docente_Curso>>? listadoDictados;
        private Task<IEnumerable<Especialidad>>? listadoEspecialidades;
        private Task<IEnumerable<Alumno_Inscripcion>>? listadoInscripciones;
        private Task<IEnumerable<Materia>>? listadoMaterias;
        private Task<IEnumerable<Persona>>? listadoPersonas;
        private Task<IEnumerable<Plan>>? listadoPlanes;
        private Task<IEnumerable<Usuario>>? listadoUsuarios;

        private List<ComisionViewModel> listadoComisionesViewModel;
        private List<CursoViewModel> listadoCursosViewModel;
        private List<DictadoViewModel> listadoDictadosViewModel;
        private List<EspecialidadViewModel> listadoEspecialidadesViewModel;
        private List<InscripcionViewModel> listadoInscripcionesViewModel;
        private List<InscripcionAlumnoViewModel> listadoInscripcionesAlumnoViewModel;
        private List<MateriaViewModel> listadoMateriasViewModel;
        private List<PersonaViewModel> listadoPersonasViewModel;
        private List<PlanViewModel> listadoPlanesViewModel;
        private List<UsuarioViewModel> listadoUsuariosViewModel;
        private List<InscripcionCursoDocenteViewModel> listadoInscripcionesCursosDocenteViewModel;

        public Grilla(Usuario usuarioAutenticado)
        {
            InitializeComponent();

            this.usuarioAutenticado = usuarioAutenticado;

            ConfigurarInterfaz();
        }

        public void ConfigurarInterfaz()
        {
            BarraBusqueda.Enabled = false;
            BarraBusqueda.BackColor = Color.WhiteSmoke;

            dgvSysacad.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSysacad.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            tsbNuevo.Enabled = false;
            tsbEditar.Enabled = false;
            tsbEliminar.Enabled = false;

            List<Button> botonesAOcultarAlumno = new List<Button> { btnMostrarAlumnosPorPlan, btnMostrarInscripcionesPorCurso, btnMostrarComisiones, btnMostrarCursos, btnMostrarDictados, btnMostrarEspecialidades, btnMostrarInscripciones, btnMostrarMaterias, btnMostrarPersonas, btnMostrarPlanes, btnMostrarUsuarios, btnMostrarInscripcionesATusCursos, btnMostrarCondicionDeAlumnos };

            List<Button> botonesAOcultarDocente = new List<Button> { btnMostrarAlumnosPorPlan, btnMostrarInscripcionesPorCurso, btnMostrarComisiones, btnMostrarCursos, btnMostrarDictados, btnMostrarEspecialidades, btnMostrarInscripciones, btnMostrarMaterias, btnMostrarPersonas, btnMostrarPlanes, btnMostrarUsuarios, btnMostrarTusInscripciones, btnMostrarRendimientoDelAlumno };

            List<Button> botonesAOcultarAdministrador = new List<Button> { btnMostrarTusInscripciones, btnMostrarRendimientoDelAlumno, btnMostrarInscripcionesATusCursos, btnMostrarCondicionDeAlumnos };

            if (usuarioAutenticado.Rol == 0)
            {

                tsbEditar.Visible = false;

                OcultarBotones(botonesAOcultarAlumno);

            }
            else if (usuarioAutenticado.Rol == 1)
            {

                tsbNuevo.Visible = false;
                tsbEliminar.Visible = false;

                OcultarBotones(botonesAOcultarDocente);

            }
            else if (usuarioAutenticado.Rol == 2)
            {

                OcultarBotones(botonesAOcultarAdministrador);

            }
        }

        public void OcultarBotones(List<Button> botonesAOcultar)
        {
            foreach (Button boton in botonesAOcultar)
            {
                boton.Visible = false;
            }
        }

        public IEnumerable<T> LeerEntidades<T>()
        {
            try
            {
                if (typeof(T) == typeof(Comision))
                {
                    this.listadoComisiones = ComisionNegocio.GetAll();
                    entidadListada = "Comision";
                    return (IEnumerable<T>)this.listadoComisiones.Result;
                }
                else if (typeof(T) == typeof(Curso))
                {
                    if (usuarioAutenticado.Rol == 0 || usuarioAutenticado.Rol == 1)
                    {
                        this.listadoCursos = CursoNegocio.GetCursosParaPersona(usuarioAutenticado.Persona?.Id_persona.ToString() ?? "0");
                    }
                    else if (usuarioAutenticado.Rol == 2)
                    {
                        this.listadoCursos = CursoNegocio.GetAll();
                    }

                    entidadListada = "Curso";
                    return (IEnumerable<T>)this.listadoCursos.Result;
                }
                else if (typeof(T) == typeof(Docente_Curso))
                {
                    this.listadoDictados = DictadoNegocio.GetAll();
                    entidadListada = "Dictado";
                    return (IEnumerable<T>)this.listadoDictados.Result;
                }
                else if (typeof(T) == typeof(Especialidad))
                {
                    this.listadoEspecialidades = EspecialidadNegocio.GetAll();
                    entidadListada = "Especialidad";
                    return (IEnumerable<T>)this.listadoEspecialidades.Result;
                }
                else if (typeof(T) == typeof(Alumno_Inscripcion))
                {
                    if (usuarioAutenticado.Rol == 0)
                    {
                        this.listadoInscripciones = InscripcionNegocio.GetInscripcionesPorAlumno(usuarioAutenticado.Persona?.Id_persona.ToString() ?? "0");
                        entidadListada = "InscripcionAlumno";
                    }
                    else if (usuarioAutenticado.Rol == 1)
                    {
                        this.listadoInscripciones = InscripcionNegocio.GetInscripcionesCursosDocente(usuarioAutenticado.Persona?.Id_persona.ToString() ?? "0");
                        entidadListada = "InscripcionCursoDocente";
                    }
                    else
                    {
                        this.listadoInscripciones = InscripcionNegocio.GetAll();
                        entidadListada = "Inscripcion";
                    }

                    return (IEnumerable<T>)this.listadoInscripciones.Result;
                }
                else if (typeof(T) == typeof(Materia))
                {
                    this.listadoMaterias = MateriaNegocio.GetAll();
                    entidadListada = "Materia";
                    return (IEnumerable<T>)this.listadoMaterias.Result;
                }
                else if (typeof(T) == typeof(Persona))
                {
                    this.listadoPersonas = PersonaNegocio.GetAll();
                    entidadListada = "Persona";
                    return (IEnumerable<T>)this.listadoPersonas.Result;
                }
                else if (typeof(T) == typeof(Plan))
                {
                    this.listadoPlanes = PlanNegocio.GetAll();
                    entidadListada = "Plan";
                    return (IEnumerable<T>)this.listadoPlanes.Result;
                }
                else if (typeof(T) == typeof(Usuario))
                {
                    this.listadoUsuarios = UsuarioNegocio.GetAll();
                    entidadListada = "Usuario";
                    return (IEnumerable<T>)this.listadoUsuarios.Result;
                }
                else
                {
                    entidadListada = "";
                    return null;
                }
            }
            catch (Exception)
            {
                ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Error al conectarse a la base de datos!");
                this.Invoke(new Action(() => errorBD.ShowDialog(this)));

                entidadListada = "";
                return null;
            }
        }

        private void SeleccionarPrimeraFila()
        {
            if (dgvSysacad.Rows.Count > 0)
            {
                dgvSysacad.Rows[0].Selected = true;
            }
        }

        private async void tsbNuevo_Click(object sender, EventArgs e)
        {
            if (entidadListada == "Comision")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                entidadListada = "Comision";

                if (planes.Any())
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    ComisionUI nuevaComision = new ComisionUI(opcionesPlan);
                    if (nuevaComision.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarComisiones_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Debe haber al menos un plan registrado previamente!");
                    errorBD.ShowDialog(this);
                }
            }
            else if (entidadListada == "Curso")
            {
                Task<IEnumerable<Comision>> task1 = new Task<IEnumerable<Comision>>(LeerEntidades<Comision>);
                task1.Start();
                IEnumerable<Comision> comisiones = await task1;

                entidadListada = "Curso";

                if (comisiones.Any())
                {
                    List<(int Id, string Descripcion)> opcionesComision = comisiones.Select(comision => (comision.Id_comision, comision.Desc_comision)).ToList();

                    CursoUI nuevoCurso = new CursoUI(opcionesComision);
                    if (nuevoCurso.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarCursos_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Debe haber al menos una comisión registrada previamente!");
                    errorBD.ShowDialog(this);
                }
            }
            else if (entidadListada == "Dictado")
            {
                Task<IEnumerable<Persona>> task1 = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task1.Start();
                IEnumerable<Persona> docentes = await task1;

                entidadListada = "Dictado";

                if (docentes.Any())
                {
                    List<(int Id, string ApellidoYNombre)> opcionesDocente = docentes.Where(docente => docente.Tipo_persona == 1)
                                                                                        .Select(docente => (docente.Id_persona, docente.Apellido + ", " + docente.Nombre)).ToList();

                    DictadoUI nuevoDictado = new DictadoUI(opcionesDocente);
                    var result = nuevoDictado.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else if (result == DialogResult.Abort)
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", nuevoDictado.Mensaje);
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarDictados_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Debe haber al menos un docente registrado previamente!");
                    errorBD.ShowDialog(this);
                }
            }
            else if (entidadListada == "Especialidad")
            {
                EspecialidadUI nuevaEspecialidad = new EspecialidadUI();
                if (nuevaEspecialidad.ShowDialog(this) == DialogResult.OK)
                {
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
                btnMostrarEspecialidades_Click(sender, e);
            }
            else if (entidadListada == "Inscripcion")
            {
                Task<IEnumerable<Persona>> task1 = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task1.Start();
                IEnumerable<Persona> alumnos = await task1;

                entidadListada = "Inscripcion";

                if (alumnos.Any())
                {
                    List<(int Id, string ApellidoYNombre)> opcionesAlumno = alumnos.Where(alumno => alumno.Tipo_persona == 0)
                                                                                      .Select(alumno => (alumno.Id_persona, alumno.Apellido + ", " + alumno.Nombre)).ToList();

                    InscripcionUI nuevaInscripcion = new InscripcionUI(opcionesAlumno);

                    var result = nuevaInscripcion.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else if (result == DialogResult.Abort)
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", nuevaInscripcion.Mensaje);
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarInscripciones_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Debe haber al menos un alumno registrado previamente!");
                    errorBD.ShowDialog(this);
                }
            }
            else if (entidadListada == "Materia")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                entidadListada = "Materia";

                if (planes.Any())
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    MateriaUI nuevaMateria = new MateriaUI(opcionesPlan);
                    if (nuevaMateria.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarMaterias_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Debe haber al menos un plan registrado previamente!");
                    errorBD.ShowDialog(this);
                }
            }
            else if (entidadListada == "Persona")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                entidadListada = "Persona";

                if (planes.Any())
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    PersonaUI nuevaPersona = new PersonaUI(opcionesPlan);
                    if (nuevaPersona.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarPersonas_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Debe haber al menos un plan registrado previamente!");
                    errorBD.ShowDialog(this);
                }
            }
            else if (entidadListada == "Plan")
            {
                Task<IEnumerable<Especialidad>> task = new Task<IEnumerable<Especialidad>>(LeerEntidades<Especialidad>);
                task.Start();
                IEnumerable<Especialidad> especialidades = await task;

                entidadListada = "Plan";

                if (especialidades.Any())
                {
                    List<(int Id, string Descripcion)> opcionesEspecialidad = especialidades.Select(especialidad => (especialidad.Id_especialidad, especialidad.Desc_especialidad)).ToList();

                    PlanUI nuevoPlan = new PlanUI(opcionesEspecialidad);
                    if (nuevoPlan.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarPlanes_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "Debe haber al menos una especialidad registrada previamente!");
                    errorBD.ShowDialog(this);
                }
            }
            else if (entidadListada == "Usuario")
            {
                Task<IEnumerable<Persona>> task = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task.Start();
                IEnumerable<Persona> personas = await task;

                entidadListada = "Usuario";

                if (personas != null)
                {
                    List<(int Id, string ApellidoYNombre)> opcionesPersona = personas.Select(persona => (persona.Id_persona, persona.Apellido + ", " + persona.Nombre)).ToList();

                    UsuarioUI nuevaPersona = new UsuarioUI(opcionesPersona);
                    if (nuevaPersona.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarUsuarios_Click(sender, e);
                }
            }
            else if (entidadListada == "InscripcionAlumno")
            {
                Task<IEnumerable<Curso>> task = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                task.Start();
                IEnumerable<Curso> cursosParaAlumno = await task;

                entidadListada = "InscripcionAlumno";

                if (cursosParaAlumno.Any())
                {
                    List<(int Id, string MateriaYComision)> opcionesCursoParaAlumno = cursosParaAlumno.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                    InscripcionAlumnoUI nuevaInscripcion = new InscripcionAlumnoUI(usuarioAutenticado.Persona.Id_persona, opcionesCursoParaAlumno);

                    var result = nuevaInscripcion.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                    }
                    else if (result == DialogResult.Abort)
                    {
                        if (nuevaInscripcion.Mensaje != "El curso no tiene más cupos disponibles")
                        {
                            nuevaInscripcion.Mensaje = "Ya estás inscripto a la materia";
                        }

                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", nuevaInscripcion.Mensaje);
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarTusInscripciones_Click(sender, e);
                }
                else
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "No hay cursos registrados para tu plan de estudios!");
                    errorBD.ShowDialog(this);
                }
            }
        }

        private async void tsbEditar_Click(object sender, EventArgs e)
        {
            if (entidadListada == "Comision")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                entidadListada = "Comision";

                if (planes != null)
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((ComisionViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var comisionSeleccionada = listadoComisiones.Result.FirstOrDefault(com => com.Id_comision == idSeleccionado);

                    ComisionUI editarComision = new ComisionUI(opcionesPlan, comisionSeleccionada);

                    if (editarComision.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarComisiones_Click(sender, e);
                }
            }
            else if (entidadListada == "Curso")
            {
                Task<IEnumerable<Comision>> task1 = new Task<IEnumerable<Comision>>(LeerEntidades<Comision>);
                task1.Start();
                IEnumerable<Comision> comisiones = await task1;

                entidadListada = "Curso";

                if (comisiones != null)
                {
                    Task<IEnumerable<Materia>> task2 = new Task<IEnumerable<Materia>>(LeerEntidades<Materia>);
                    task2.Start();
                    IEnumerable<Materia> materias = await task2;

                    entidadListada = "Curso";

                    if (materias != null)
                    {
                        List<(int Id, string Descripcion)> opcionesComision = comisiones.Select(comision => (comision.Id_comision, comision.Desc_comision)).ToList();
                        List<(int Id, string Descripcion)> opcionesMateria = materias.Select(materia => (materia.Id_materia, materia.Desc_materia)).ToList();

                        int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                        int idSeleccionado = ((CursoViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                        var cursoSeleccionado = listadoCursos.Result.FirstOrDefault(cur => cur.Id_curso == idSeleccionado);

                        CursoUI editarCurso = new CursoUI(opcionesComision, opcionesMateria, cursoSeleccionado);

                        if (editarCurso.ShowDialog(this) == DialogResult.OK)
                        {
                            OperacionExitosa operacionExitosa = new OperacionExitosa();
                            operacionExitosa.ShowDialog(this);
                        }
                        btnMostrarCursos_Click(sender, e);
                    }
                }
            }
            else if (entidadListada == "Dictado")
            {
                Task<IEnumerable<Persona>> task1 = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task1.Start();
                IEnumerable<Persona> docentes = await task1;

                entidadListada = "Dictado";

                if (docentes != null)
                {
                    Task<IEnumerable<Curso>> task2 = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                    task2.Start();
                    IEnumerable<Curso> cursos = await task2;

                    entidadListada = "Dictado";

                    if (cursos != null)
                    {
                        List<(int Id, string ApellidoYNombre)> opcionesDocente = docentes.Where(docente => docente.Tipo_persona == 1)
                                                                                            .Select(docente => (docente.Id_persona, docente.Apellido + ", " + docente.Nombre)).ToList();

                        List<(int Id, string MateriaYComision)> opcionesCurso = cursos.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                        int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                        int idSeleccionado = ((DictadoViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                        var dictadoSeleccionado = listadoDictados.Result.FirstOrDefault(dic => dic.Id_dictado == idSeleccionado);

                        DictadoUI editarDictado = new DictadoUI(opcionesDocente, opcionesCurso, dictadoSeleccionado);

                        if (editarDictado.ShowDialog(this) == DialogResult.OK)
                        {
                            OperacionExitosa operacionExitosa = new OperacionExitosa();
                            operacionExitosa.ShowDialog(this);
                        }
                        btnMostrarDictados_Click(sender, e);
                    }
                }
            }
            else if (entidadListada == "Especialidad")
            {
                int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                int idSeleccionado = ((EspecialidadViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                var especialidadSeleccionada = listadoEspecialidades.Result.FirstOrDefault(esp => esp.Id_especialidad == idSeleccionado);

                EspecialidadUI editarEspecialidad = new EspecialidadUI(especialidadSeleccionada);

                if (editarEspecialidad.ShowDialog(this) == DialogResult.OK)
                {
                    OperacionExitosa operacionExitosa = new OperacionExitosa();
                    operacionExitosa.ShowDialog(this);
                }
                btnMostrarEspecialidades_Click(sender, e);
            }
            else if (entidadListada == "Inscripcion")
            {
                Task<IEnumerable<Persona>> task1 = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task1.Start();
                IEnumerable<Persona> alumnos = await task1;

                entidadListada = "Inscripcion";

                if (alumnos != null)
                {
                    Task<IEnumerable<Curso>> task2 = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                    task2.Start();
                    IEnumerable<Curso> cursos = await task2;

                    entidadListada = "Inscripcion";

                    if (cursos != null)
                    {
                        List<(int Id, string ApellidoYNombre)> opcionesAlumno = alumnos.Where(alumno => alumno.Tipo_persona == 0)
                                                                                          .Select(alumno => (alumno.Id_persona, alumno.Apellido + ", " + alumno.Nombre)).ToList();

                        List<(int Id, string MateriaYComision)> opcionesCurso = cursos.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                        int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                        int idSeleccionado = ((InscripcionViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                        var inscripcionSeleccionada = listadoInscripciones.Result.FirstOrDefault(ins => ins.Id_inscripcion == idSeleccionado);

                        InscripcionUI editarInscripcion = new InscripcionUI(opcionesAlumno, opcionesCurso, inscripcionSeleccionada);

                        if (editarInscripcion.ShowDialog(this) == DialogResult.OK)
                        {
                            OperacionExitosa operacionExitosa = new OperacionExitosa();
                            operacionExitosa.ShowDialog(this);
                        }
                        btnMostrarInscripciones_Click(sender, e);
                    }
                }
            }
            else if (entidadListada == "Materia")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                entidadListada = "Materia";

                if (planes != null)
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((MateriaViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var materiaSeleccionada = listadoMaterias.Result.FirstOrDefault(mat => mat.Id_materia == idSeleccionado);

                    MateriaUI editarMateria = new MateriaUI(opcionesPlan, materiaSeleccionada);

                    if (editarMateria.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarMaterias_Click(sender, e);
                }
            }
            else if (entidadListada == "Persona")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                entidadListada = "Persona";

                if (planes != null)
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((PersonaViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var personaSeleccionada = listadoPersonas.Result.FirstOrDefault(per => per.Id_persona == idSeleccionado);

                    PersonaUI editarPersona = new PersonaUI(opcionesPlan, personaSeleccionada);

                    if (editarPersona.ShowDialog(this) == DialogResult.OK)
                    {

                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarPersonas_Click(sender, e);
                }
            }
            else if (entidadListada == "Plan")
            {
                Task<IEnumerable<Especialidad>> task = new Task<IEnumerable<Especialidad>>(LeerEntidades<Especialidad>);
                task.Start();
                IEnumerable<Especialidad> especialidades = await task;

                entidadListada = "Plan";

                if (especialidades != null)
                {
                    List<(int Id, string Descripcion)> opcionesEspecialidad = especialidades.Select(especialidad => (especialidad.Id_especialidad, especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((PlanViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var planSeleccionado = listadoPlanes.Result.FirstOrDefault(pla => pla.Id_plan == idSeleccionado);

                    PlanUI editarPlan = new PlanUI(opcionesEspecialidad, planSeleccionado);

                    if (editarPlan.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarPlanes_Click(sender, e);
                }
            }
            else if (entidadListada == "Usuario")
            {
                Task<IEnumerable<Persona>> task = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task.Start();
                IEnumerable<Persona> personas = await task;

                entidadListada = "Usuario";

                if (personas != null)
                {
                    List<(int Id, string ApellidoYNombre)> opcionesPersona = personas.Select(persona => (persona.Id_persona, persona.Apellido + ", " + persona.Nombre)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((UsuarioViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var usuarioSeleccionado = listadoUsuarios.Result.FirstOrDefault(usu => usu.Id_usuario == idSeleccionado);

                    UsuarioUI editarUsuario = new UsuarioUI(opcionesPersona, usuarioSeleccionado);

                    if (editarUsuario.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarUsuarios_Click(sender, e);
                }
            }
            else if (entidadListada == "InscripcionCursoDocente")
            {
                Task<IEnumerable<Persona>> task1 = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task1.Start();
                IEnumerable<Persona> alumnos = await task1;

                entidadListada = "InscripcionCursoDocente";

                if (alumnos != null)
                {
                    Task<IEnumerable<Curso>> task2 = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                    task2.Start();
                    IEnumerable<Curso> cursos = await task2;

                    entidadListada = "InscripcionCursoDocente";

                    if (cursos != null)
                    {
                        List<(int Id, string ApellidoYNombre)> opcionesAlumno = alumnos.Where(alumno => alumno.Tipo_persona == 0)
                                                                                          .Select(alumno => (alumno.Id_persona, alumno.Apellido + ", " + alumno.Nombre)).ToList();

                        List<(int Id, string MateriaYComision)> opcionesCurso = cursos.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                        int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                        int idSeleccionado = ((InscripcionCursoDocenteViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                        var inscripcionSeleccionada = listadoInscripciones.Result.FirstOrDefault(ins => ins.Id_inscripcion == idSeleccionado);

                        InscripcionCursoDocenteUI editarInscripcion = new InscripcionCursoDocenteUI(opcionesAlumno, opcionesCurso, inscripcionSeleccionada);

                        if (editarInscripcion.ShowDialog(this) == DialogResult.OK)
                        {
                            OperacionExitosa operacionExitosa = new OperacionExitosa();
                            operacionExitosa.ShowDialog(this);
                        }
                        btnMostrarInscripcionesATusCursos_Click(sender, e);
                    }
                }
            }
        }

        private async void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (entidadListada == "Comision")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((ComisionViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var comisionSeleccionada = listadoComisiones.Result.FirstOrDefault(com => com.Id_comision == idSeleccionado);

                    var response = await ComisionNegocio.Delete(comisionSeleccionada);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La comisión tiene cursos asociados");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarComisiones_Click(sender, e);
                }
            }
            else if (entidadListada == "Curso")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((CursoViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var cursoSeleccionado = listadoCursos.Result.FirstOrDefault(cur => cur.Id_curso == idSeleccionado);

                    var response = await CursoNegocio.Delete(cursoSeleccionado);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "El curso tiene inscripciones y/o dictados asociados");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarCursos_Click(sender, e);
                }
            }
            else if (entidadListada == "Dictado")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((DictadoViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var dictadoSeleccionado = listadoDictados.Result.FirstOrDefault(dic => dic.Id_dictado == idSeleccionado);

                    var response = await DictadoNegocio.Delete(dictadoSeleccionado);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La operación no se ha podido llevar a cabo");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarDictados_Click(sender, e);
                }
            }
            else if (entidadListada == "Especialidad")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((EspecialidadViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var especialidadSeleccionada = listadoEspecialidades.Result.FirstOrDefault(esp => esp.Id_especialidad == idSeleccionado);

                    var response = await EspecialidadNegocio.Delete(especialidadSeleccionada);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La especialidad tiene planes asociados");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarEspecialidades_Click(sender, e);
                }
            }
            else if (entidadListada == "Inscripcion")
            {
                int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                int idSeleccionado = ((InscripcionViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                var inscripcionSeleccionada = listadoInscripciones.Result.FirstOrDefault(ins => ins.Id_inscripcion == idSeleccionado);

                Alumno_Inscripcion inscripcion = inscripcionSeleccionada;

                if (inscripcion.Condicion != "Inscripto")
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La inscripción no se puede eliminar porque ya fue modificada");
                    errorBD.ShowDialog(this);
                }
                else
                {
                    ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                    if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                    {
                        var response = await InscripcionNegocio.Delete(inscripcion);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            OperacionExitosa operacionExitosa = new OperacionExitosa();
                            operacionExitosa.ShowDialog(this);
                        }
                        else
                        {
                            ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                            errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La operación no se ha podido llevar a cabo");
                            errorBD.ShowDialog(this);
                        }
                        btnMostrarInscripciones_Click(sender, e);
                    }
                }
            }
            else if (entidadListada == "Materia")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((MateriaViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var materiaSeleccionada = listadoMaterias.Result.FirstOrDefault(mat => mat.Id_materia == idSeleccionado);

                    var response = await MateriaNegocio.Delete(materiaSeleccionada);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La materia tiene cursos asociados");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarMaterias_Click(sender, e);
                }
            }
            else if (entidadListada == "Persona")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((PersonaViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var personaSeleccionada = listadoPersonas.Result.FirstOrDefault(per => per.Id_persona == idSeleccionado);

                    var response = await PersonaNegocio.Delete(personaSeleccionada);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La persona tiene dictados, inscripciones y/o usuarios asociados");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarPersonas_Click(sender, e);
                }
            }
            else if (entidadListada == "Plan")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((PlanViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var planSeleccionado = listadoPlanes.Result.FirstOrDefault(pla => pla.Id_plan == idSeleccionado);

                    var response = await PlanNegocio.Delete(planSeleccionado);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "El plan tiene comisiones, materias y/o personas asociadas");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarPlanes_Click(sender, e);
                }
            }
            else if (entidadListada == "Usuario")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    int idSeleccionado = ((UsuarioViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                    var usuarioSeleccionado = listadoUsuarios.Result.FirstOrDefault(usu => usu.Id_usuario == idSeleccionado);

                    var response = await UsuarioNegocio.Delete(usuarioSeleccionado);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La operación no se ha podido llevar a cabo");
                        errorBD.ShowDialog(this);
                    }
                    btnMostrarUsuarios_Click(sender, e);
                }
            }
            else if (entidadListada == "InscripcionAlumno")
            {
                int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                int idSeleccionado = ((InscripcionAlumnoViewModel)dgvSysacad.Rows[filaSeleccionada].DataBoundItem).Id;

                var inscripcionSeleccionada = listadoInscripciones.Result.FirstOrDefault(ins => ins.Id_inscripcion == idSeleccionado);

                Alumno_Inscripcion inscripcion = inscripcionSeleccionada;

                if (inscripcion.Condicion != "Inscripto")
                {
                    ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                    errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La inscripción no se puede eliminar porque ya fue modificada");
                    errorBD.ShowDialog(this);
                }
                else
                {
                    ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                    if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                    {
                        var response = await InscripcionNegocio.Delete(inscripcion);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            OperacionExitosa operacionExitosa = new OperacionExitosa();
                            operacionExitosa.ShowDialog(this);
                        }
                        else
                        {
                            ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                            errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La operación no se ha podido llevar a cabo");
                            errorBD.ShowDialog(this);
                        }
                        btnMostrarInscripciones_Click(sender, e);
                    }
                }
            }
        }

        private async void btnMostrarComisiones_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Comision>> task = new Task<IEnumerable<Comision>>(LeerEntidades<Comision>);
            task.Start();

            var comisiones = await task;

            if (comisiones.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Descripcion, Plan o Especialidad...";
                BarraBusqueda.BackColor = Color.White;

                comisiones = comisiones.OrderBy(com => com.Plan.Especialidad.Desc_especialidad)
                                          .ThenByDescending(com => com.Plan.Desc_plan)
                                             .ThenBy(com => com.Anio_especialidad)
                                                .ThenBy(com => com.Desc_comision);

                var comisionesViewModel = comisiones.Select(comision => new ComisionViewModel
                {
                    Id = comision.Id_comision,
                    Descripcion = comision.Desc_comision,
                    AnioEspecialidad = comision.Anio_especialidad,
                    Plan = comision.Plan.Desc_plan + " - " + comision.Plan.Especialidad.Desc_especialidad

                }).ToList();

                this.listadoComisionesViewModel = comisionesViewModel;

                dgvSysacad.DataSource = comisionesViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay comisiones registradas!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Curso>> task = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
            task.Start();

            var cursos = await task;

            if (cursos.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Año Calendario, Comision o Materia...";
                BarraBusqueda.BackColor = Color.White;

                cursos = cursos.OrderByDescending(cur => cur.Anio_calendario)
                                  .ThenBy(cur => cur.Materia.Desc_materia)
                                     .ThenBy(cur => cur.Comision.Desc_comision);

                var cursosViewModel = cursos.Select(curso => new CursoViewModel
                {
                    Id = curso.Id_curso,
                    AnioCalendario = curso.Anio_calendario.ToString(),
                    Cupo = curso.Cupo.ToString(),
                    Materia = curso.Materia.Desc_materia,
                    Comision = curso.Comision.Desc_comision

                }).ToList();

                this.listadoCursosViewModel = cursosViewModel;

                dgvSysacad.DataSource = cursosViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay cursos registrados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarDictados_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Docente_Curso>> task = new Task<IEnumerable<Docente_Curso>>(LeerEntidades<Docente_Curso>);
            task.Start();

            var dictados = await task;

            if (dictados.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Cargo, Docente, Comision o Materia...";
                BarraBusqueda.BackColor = Color.White;

                dictados = dictados.OrderBy(dic => dic.Curso.Materia.Desc_materia)
                                      .ThenBy(dic => dic.Curso.Comision.Desc_comision)
                                         .ThenBy(dic => dic.Docente.Apellido)
                                            .ThenBy(dic => dic.Docente.Nombre)
                                               .ThenBy(dic => dic.Cargo);

                var dictadosViewModel = dictados.Select(dictado => new DictadoViewModel
                {
                    Id = dictado.Id_dictado,
                    Cargo = dictado.Cargo,
                    Docente = dictado.Docente.Apellido + ", " + dictado.Docente.Nombre,
                    Curso = dictado.Curso.Materia.Desc_materia + " - " + dictado.Curso.Comision.Desc_comision,

                }).ToList();

                this.listadoDictadosViewModel = dictadosViewModel;

                dgvSysacad.DataSource = dictadosViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay dictados registrados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarEspecialidades_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Especialidad>> task = new Task<IEnumerable<Especialidad>>(LeerEntidades<Especialidad>);
            task.Start();

            var especialidades = await task;

            if (especialidades.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Descripcion...";
                BarraBusqueda.BackColor = Color.White;

                especialidades = especialidades.OrderBy(esp => esp.Desc_especialidad);

                var especialidadesViewModel = especialidades.Select(especialidad => new EspecialidadViewModel
                {
                    Id = especialidad.Id_especialidad,
                    Descripcion = especialidad.Desc_especialidad

                }).ToList();

                this.listadoEspecialidadesViewModel = especialidadesViewModel;

                dgvSysacad.DataSource = especialidadesViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay especialidades registradas!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarInscripciones_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Alumno_Inscripcion>> task = new Task<IEnumerable<Alumno_Inscripcion>>(LeerEntidades<Alumno_Inscripcion>);
            task.Start();

            var inscripciones = await task;

            if (inscripciones.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Condicion, Alumno, Comision o Materia...";
                BarraBusqueda.BackColor = Color.White;

                var condicionOrden = new Dictionary<string, int>
                {
                    { "Aprobado", 0 },
                    { "Regular", 1 },
                    { "Libre", 2 },
                    { "Inscripto", 3 }
                };

                inscripciones = inscripciones.OrderBy(ins => condicionOrden[ins.Condicion])
                                                .ThenBy(ins => ins.Curso.Materia.Desc_materia)
                                                   .ThenBy(ins => ins.Curso.Comision.Desc_comision)
                                                      .ThenByDescending(ins => ins.Nota)
                                                         .ThenBy(ins => ins.Alumno.Apellido)
                                                            .ThenBy(ins => ins.Alumno.Nombre);

                var inscripcionesViewModel = inscripciones.Select(inscripcion => new InscripcionViewModel
                {
                    Id = inscripcion.Id_inscripcion,
                    Condicion = inscripcion.Condicion,
                    Nota = inscripcion.Nota == 0 ? "-" : inscripcion.Nota.ToString(),
                    Alumno = inscripcion.Alumno.Apellido + ", " + inscripcion.Alumno.Nombre,
                    Curso = inscripcion.Curso.Materia.Desc_materia + " - " + inscripcion.Curso.Comision.Desc_comision

                }).ToList();

                this.listadoInscripcionesViewModel = inscripcionesViewModel;

                dgvSysacad.DataSource = inscripcionesViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay inscripciones registradas!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarMaterias_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Materia>> task = new Task<IEnumerable<Materia>>(LeerEntidades<Materia>);
            task.Start();

            var materias = await task;

            if (materias.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Descripcion, Plan o Especialidad...";
                BarraBusqueda.BackColor = Color.White;

                materias = materias.OrderBy(mat => mat.Plan.Especialidad.Desc_especialidad)
                                      .ThenByDescending(mat => mat.Plan.Desc_plan)
                                         .ThenBy(mat => mat.Desc_materia);

                var materiasViewModel = materias.Select(materia => new MateriaViewModel
                {
                    Id = materia.Id_materia,
                    Descripcion = materia.Desc_materia,
                    HorasSemanales = materia.Hs_semanales.ToString(),
                    HorasTotales = materia.Hs_totales.ToString(),
                    Plan = materia.Plan.Desc_plan + " - " + materia.Plan.Especialidad.Desc_especialidad

                }).ToList();

                this.listadoMateriasViewModel = materiasViewModel;

                dgvSysacad.DataSource = materiasViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay materias registradas!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarPersonas_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Persona>> task = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
            task.Start();

            var personas = await task;

            if (personas.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Apellido y Nombre, Legajo, Tipo de Persona, Plan o Especialidad...";
                BarraBusqueda.BackColor = Color.White;

                personas = personas.OrderBy(per => per.Plan.Especialidad.Desc_especialidad)
                                      .ThenByDescending(per => per.Plan.Desc_plan)
                                         .ThenBy(per => per.Tipo_persona)
                                            .ThenBy(per => per.Apellido)
                                               .ThenBy(per => per.Nombre)
                                                  .ThenByDescending(per => per.Legajo);

                var personasViewModel = personas.Select(persona => new PersonaViewModel
                {
                    Id = persona.Id_persona,
                    ApellidoYNombre = persona.Apellido + ", " + persona.Nombre,
                    FechaNacimiento = persona.Fecha_nac.ToString("dd/MM/yyyy"),
                    Legajo = persona.Legajo.ToString(),
                    Tipo = persona.Tipo_persona == 0 ? "Alumno" : "Docente",
                    Plan = persona.Plan.Desc_plan + " - " + persona.Plan.Especialidad.Desc_especialidad

                }).ToList();

                this.listadoPersonasViewModel = personasViewModel;

                dgvSysacad.DataSource = personasViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay personas registradas!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarPlanes_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
            task.Start();

            var planes = await task;

            if (planes.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Descripcion o Especialidad...";
                BarraBusqueda.BackColor = Color.White;

                planes = planes.OrderBy(pla => pla.Especialidad.Desc_especialidad)
                                  .ThenByDescending(pla => pla.Desc_plan);

                var planesViewModel = planes.Select(plan => new PlanViewModel
                {
                    Id = plan.Id_plan,
                    Descripcion = plan.Desc_plan,
                    Especialidad = plan.Especialidad.Desc_especialidad

                }).ToList();

                this.listadoPlanesViewModel = planesViewModel;

                dgvSysacad.DataSource = planesViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay planes registrados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarUsuarios_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Usuario>> task = new Task<IEnumerable<Usuario>>(LeerEntidades<Usuario>);
            task.Start();

            var usuarios = await task;

            if (usuarios.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Nombre de Usuario, Rol o Persona...";
                BarraBusqueda.BackColor = Color.White;

                var rolOrden = new Dictionary<int, int>
                {
                    { 2, 0 }, // Administrador (ID 2 en BD)
                    { 0, 1 }, // Alumno (ID 0 en BD)
                    { 1, 2 }  // Docente (ID 1 en BD)
                };

                usuarios = usuarios.OrderBy(usu => rolOrden[usu.Rol])
                                      .ThenBy(usu => usu.Persona?.Apellido)
                                         .ThenBy(usu => usu.Persona?.Nombre)
                                            .ThenBy(usu => usu.Nombre_usuario);

                var usuariosViewModel = usuarios.Select(usuario => new UsuarioViewModel
                {
                    Id = usuario.Id_usuario,
                    NombreUsuario = usuario.Nombre_usuario,
                    Clave = usuario.Clave,
                    Rol = usuario.Rol == 0 ? "Alumno" : (usuario.Rol == 1 ? "Docente" : "Administrador"),
                    Persona = usuario.Persona == null ? "-" : (usuario.Persona.Apellido + ", " + usuario.Persona.Nombre)

                }).ToList();

                this.listadoUsuariosViewModel = usuariosViewModel;

                dgvSysacad.DataSource = usuariosViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEditar.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay usuarios registrados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarTusInscripciones_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Alumno_Inscripcion>> task = new Task<IEnumerable<Alumno_Inscripcion>>(LeerEntidades<Alumno_Inscripcion>);
            task.Start();

            var tusInscripciones = await task;

            if (tusInscripciones.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Condicion, Comision o Materia...";
                BarraBusqueda.BackColor = Color.White;

                var condicionOrden = new Dictionary<string, int>
                {
                    { "Aprobado", 0 },
                    { "Regular", 1 },
                    { "Libre", 2 },
                    { "Inscripto", 3 }
                };

                tusInscripciones = tusInscripciones.OrderBy(ins => condicionOrden[ins.Condicion])
                                                      .ThenBy(ins => ins.Curso.Materia.Desc_materia)
                                                         .ThenBy(ins => ins.Curso.Comision.Desc_comision)
                                                            .ThenByDescending(ins => ins.Nota);

                var inscripcionesAlumnoViewModel = tusInscripciones.Select(inscripcion => new InscripcionAlumnoViewModel
                {
                    Id = inscripcion.Id_inscripcion,
                    Condicion = inscripcion.Condicion,
                    Nota = inscripcion.Nota == 0 ? "-" : inscripcion.Nota.ToString(),
                    Curso = inscripcion.Curso.Materia.Desc_materia + " - " + inscripcion.Curso.Comision.Desc_comision

                }).ToList();

                this.listadoInscripcionesAlumnoViewModel = inscripcionesAlumnoViewModel;

                dgvSysacad.DataSource = inscripcionesAlumnoViewModel;
                SeleccionarPrimeraFila();

                tsbNuevo.Enabled = true;
                tsbEliminar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No tenés inscripciones registradas!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbNuevo.Enabled = true;
                tsbEliminar.Enabled = false;
            }
        }

        private async void btnMostrarInscripcionesATusCursos_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Alumno_Inscripcion>> task = new Task<IEnumerable<Alumno_Inscripcion>>(LeerEntidades<Alumno_Inscripcion>);
            task.Start();

            var inscripcionesATusCursos = await task;

            if (inscripcionesATusCursos.Any())
            {
                BarraBusqueda.Enabled = true;
                BarraBusqueda.Text = "";
                this.ActiveControl = null;
                BarraBusqueda.PlaceholderText = "Buscar por Condicion, Alumno, Comision o Materia...";
                BarraBusqueda.BackColor = Color.White;

                var condicionOrden = new Dictionary<string, int>
                {
                    { "Aprobado", 0 },
                    { "Regular", 1 },
                    { "Libre", 2 },
                    { "Inscripto", 3 }
                };

                inscripcionesATusCursos = inscripcionesATusCursos.OrderBy(ins => condicionOrden[ins.Condicion])
                                                                    .ThenBy(ins => ins.Curso.Materia.Desc_materia)
                                                                       .ThenBy(ins => ins.Curso.Comision.Desc_comision)
                                                                          .ThenByDescending(ins => ins.Nota)
                                                                             .ThenBy(ins => ins.Alumno.Apellido)
                                                                                .ThenBy(ins => ins.Alumno.Nombre);

                var inscripcionesCursosDocenteViewModel = inscripcionesATusCursos.Select(inscripcion => new InscripcionCursoDocenteViewModel
                {
                    Id = inscripcion.Id_inscripcion,
                    Condicion = inscripcion.Condicion,
                    Nota = inscripcion.Nota == 0 ? "-" : inscripcion.Nota.ToString(),
                    Alumno = inscripcion.Alumno.Apellido + ", " + inscripcion.Alumno.Nombre,
                    Curso = inscripcion.Curso.Materia.Desc_materia + " - " + inscripcion.Curso.Comision.Desc_comision

                }).ToList();

                this.listadoInscripcionesCursosDocenteViewModel = inscripcionesCursosDocenteViewModel;

                dgvSysacad.DataSource = inscripcionesCursosDocenteViewModel;
                SeleccionarPrimeraFila();

                tsbEditar.Enabled = true;
            }
            else
            {
                BarraBusqueda.Enabled = false;
                BarraBusqueda.Text = "";
                BarraBusqueda.BackColor = Color.WhiteSmoke;

                dgvSysacad.DataSource = null;

                MessageBox.Show("No hay inscripciones registradas para tus cursos!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tsbEditar.Enabled = false;
            }
        }

        private async void btnMostrarInscripcionesPorCurso_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> inscripcionesPorCurso = (await InscripcionNegocio.GetInscripcionesPorCurso())
                                                                .OrderBy(insCur => insCur.Key)
                                                                    .ToDictionary(insCur => insCur.Key, insCur => insCur.Value);

            if (inscripcionesPorCurso == null || !inscripcionesPorCurso.Values.Any(valor => valor != 0))
            {
                MessageBox.Show("No hay cursos registrados, o ninguno tiene inscripciones asociadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var grafico = new InscripcionesPorCurso(inscripcionesPorCurso);

                grafico.ShowDialog();
            }
        }

        private async void btnMostrarAlumnosPorPlan_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> alumnosPorPlan = await PersonaNegocio.GetAlumnosPorPlan();

            if (alumnosPorPlan == null || !alumnosPorPlan.Values.Any(valor => valor != 0))
            {
                MessageBox.Show("No hay planes registrados, o ninguno tiene alumnos asociados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var grafico = new AlumnosPorPlan(alumnosPorPlan);

                grafico.ShowDialog();
            }
        }

        private async void btnMostrarRendimientoDelAlumno_Click(object sender, EventArgs e)
        {
            IEnumerable<Alumno_Inscripcion> inscripcionesAlumno = await InscripcionNegocio.GetInscripcionesPorAlumno(usuarioAutenticado.Id_persona.ToString());

            Dictionary<string, int> rendimientoAlumno = inscripcionesAlumno
                                                           .GroupBy(inscripcion => inscripcion.Condicion)
                                                           .ToDictionary(grupo => grupo.Key, grupo => grupo.Count());

            if (rendimientoAlumno == null || !rendimientoAlumno.Values.Any(valor => valor != 0))
            {
                MessageBox.Show("No tenés inscripciones registradas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var grafico = new RendimientoDelAlumno(rendimientoAlumno);

                grafico.ShowDialog();
            }
        }
        
        private async void btnMostrarCondicionDeAlumnos_Click(object sender, EventArgs e)
        {
            IEnumerable<Alumno_Inscripcion> inscripcionesCursosDocente = await InscripcionNegocio.GetInscripcionesCursosDocente(usuarioAutenticado.Id_persona.ToString());

            Dictionary<string, int> condicionAlumnos = condicionAlumnos = inscripcionesCursosDocente
                                                          .GroupBy(inscripcion => inscripcion.Condicion)
                                                          .ToDictionary(grupo => grupo.Key, grupo => grupo.Count());

            if (condicionAlumnos == null || !condicionAlumnos.Values.Any(valor => valor != 0))
            {
                MessageBox.Show("No hay inscripciones registradas para tus cursos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var grafico = new CondicionDeAlumnos(condicionAlumnos);

                grafico.ShowDialog();
            }
        }

        private void BarraBusqueda_TextChanged(object sender, EventArgs e)
        {
            string busqueda = BarraBusqueda.Text;

            if (entidadListada == "Comision")
            {
                List<ComisionViewModel> comisionesFiltradas;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    comisionesFiltradas = listadoComisionesViewModel ?? new List<ComisionViewModel>();
                }
                else
                {
                    comisionesFiltradas = listadoComisionesViewModel?.Where(com =>
                                          com.Descripcion.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                          com.Plan.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                       ?? new List<ComisionViewModel>();
                }

                dgvSysacad.DataSource = comisionesFiltradas;

                bool hayComisiones = comisionesFiltradas.Any();
                tsbEditar.Enabled = hayComisiones;
                tsbEliminar.Enabled = hayComisiones;
            }
            else if (entidadListada == "Curso")
            {
                List<CursoViewModel> cursosFiltrados;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    cursosFiltrados = listadoCursosViewModel ?? new List<CursoViewModel>();
                }
                else
                {
                    cursosFiltrados = listadoCursosViewModel?.Where(cur =>
                                      cur.AnioCalendario.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                      cur.Comision.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                      cur.Materia.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                   ?? new List<CursoViewModel>();
                }

                dgvSysacad.DataSource = cursosFiltrados;

                bool hayCursos = cursosFiltrados.Any();
                tsbEditar.Enabled = hayCursos;
                tsbEliminar.Enabled = hayCursos;
            }
            else if (entidadListada == "Dictado")
            {
                List<DictadoViewModel> dictadosFiltrados;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    dictadosFiltrados = listadoDictadosViewModel ?? new List<DictadoViewModel>();
                }
                else
                {
                    dictadosFiltrados = listadoDictadosViewModel?.Where(dic =>
                                        dic.Cargo.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                        dic.Docente.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                        dic.Curso.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                     ?? new List<DictadoViewModel>();
                }

                dgvSysacad.DataSource = dictadosFiltrados;

                bool hayDictados = dictadosFiltrados.Any();
                tsbEditar.Enabled = hayDictados;
                tsbEliminar.Enabled = hayDictados;
            }
            else if (entidadListada == "Especialidad")
            {
                List<EspecialidadViewModel> especialidadesFiltradas;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    especialidadesFiltradas = listadoEspecialidadesViewModel ?? new List<EspecialidadViewModel>();
                }
                else
                {
                    especialidadesFiltradas = listadoEspecialidadesViewModel?.Where(esp =>
                                              esp.Descripcion.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                           ?? new List<EspecialidadViewModel>();
                }

                dgvSysacad.DataSource = especialidadesFiltradas;

                bool hayEspecialidades = especialidadesFiltradas.Any();
                tsbEditar.Enabled = hayEspecialidades;
                tsbEliminar.Enabled = hayEspecialidades;
            }
            else if (entidadListada == "Inscripcion")
            {
                List<InscripcionViewModel> inscripcionesFiltradas;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    inscripcionesFiltradas = listadoInscripcionesViewModel ?? new List<InscripcionViewModel>();
                }
                else
                {
                    inscripcionesFiltradas = listadoInscripcionesViewModel?.Where(ins =>
                                             ins.Condicion.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                             ins.Alumno.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                             ins.Curso.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                          ?? new List<InscripcionViewModel>();
                }

                dgvSysacad.DataSource = inscripcionesFiltradas;

                bool hayInscripciones = inscripcionesFiltradas.Any();
                tsbEditar.Enabled = hayInscripciones;
                tsbEliminar.Enabled = hayInscripciones;
            }
            else if (entidadListada == "InscripcionAlumno")
            {
                List<InscripcionAlumnoViewModel> inscripcionesFiltradas;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    inscripcionesFiltradas = listadoInscripcionesAlumnoViewModel ?? new List<InscripcionAlumnoViewModel>();
                }
                else
                {
                    inscripcionesFiltradas = listadoInscripcionesAlumnoViewModel?.Where(ins =>
                                             ins.Condicion.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                             ins.Curso.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                          ?? new List<InscripcionAlumnoViewModel>();
                }

                dgvSysacad.DataSource = inscripcionesFiltradas;

                bool hayInscripciones = inscripcionesFiltradas.Any();
                tsbEditar.Enabled = hayInscripciones;
                tsbEliminar.Enabled = hayInscripciones;
            }
            else if (entidadListada == "InscripcionCursoDocente")
            {
                List<InscripcionCursoDocenteViewModel> inscripcionesFiltradas;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    inscripcionesFiltradas = listadoInscripcionesCursosDocenteViewModel ?? new List<InscripcionCursoDocenteViewModel>();
                }
                else
                {
                    inscripcionesFiltradas = listadoInscripcionesCursosDocenteViewModel?.Where(ins =>
                                             ins.Condicion.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                             ins.Alumno.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                             ins.Curso.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                          ?? new List<InscripcionCursoDocenteViewModel>();
                }

                dgvSysacad.DataSource = inscripcionesFiltradas;

                bool hayInscripciones = inscripcionesFiltradas.Any();
                tsbEditar.Enabled = hayInscripciones;
                tsbEliminar.Enabled = hayInscripciones;
            }
            else if (entidadListada == "Materia")
            {
                List<MateriaViewModel> materiasFiltradas;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    materiasFiltradas = listadoMateriasViewModel ?? new List<MateriaViewModel>();
                }
                else
                {
                    materiasFiltradas = listadoMateriasViewModel?.Where(mat =>
                                        mat.Descripcion.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                        mat.Plan.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                     ?? new List<MateriaViewModel>();
                }

                dgvSysacad.DataSource = materiasFiltradas;

                bool hayMaterias = materiasFiltradas.Any();
                tsbEditar.Enabled = hayMaterias;
                tsbEliminar.Enabled = hayMaterias;
            }
            else if (entidadListada == "Persona")
            {
                List<PersonaViewModel> personasFiltradas;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    personasFiltradas = listadoPersonasViewModel ?? new List<PersonaViewModel>();
                }
                else
                {
                    personasFiltradas = listadoPersonasViewModel?.Where(per =>
                                        per.ApellidoYNombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                        per.Legajo.ToString().Contains(busqueda) ||
                                        per.Tipo.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                        per.Plan.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                     ?? new List<PersonaViewModel>();
                }

                dgvSysacad.DataSource = personasFiltradas;

                bool hayPersonas = personasFiltradas.Any();
                tsbEditar.Enabled = hayPersonas;
                tsbEliminar.Enabled = hayPersonas;
            }
            else if (entidadListada == "Plan")
            {
                List<PlanViewModel> planesFiltrados;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    planesFiltrados = listadoPlanesViewModel ?? new List<PlanViewModel>();
                }
                else
                {
                    planesFiltrados = listadoPlanesViewModel?.Where(pla =>
                                      pla.Descripcion.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                      pla.Especialidad.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList()
                                   ?? new List<PlanViewModel>();
                }

                dgvSysacad.DataSource = planesFiltrados;

                bool hayPlanes = planesFiltrados.Any();
                tsbEditar.Enabled = hayPlanes;
                tsbEliminar.Enabled = hayPlanes;
            }
            else if (entidadListada == "Usuario")
            {
                List<UsuarioViewModel> usuariosFiltrados;

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    usuariosFiltrados = listadoUsuariosViewModel ?? new List<UsuarioViewModel>();
                }
                else
                {
                    usuariosFiltrados = listadoUsuariosViewModel?.Where(usu =>
                                        usu.NombreUsuario.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                        usu.Rol.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                                       (usu.Persona != "-" &&
                                       (usu.Persona.Contains(busqueda, StringComparison.OrdinalIgnoreCase)))).ToList()
                                     ?? new List<UsuarioViewModel>();
                }

                dgvSysacad.DataSource = usuariosFiltrados;

                bool hayUsuarios = usuariosFiltrados.Any();
                tsbEditar.Enabled = hayUsuarios;
                tsbEliminar.Enabled = hayUsuarios;
            }
            SeleccionarPrimeraFila();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}