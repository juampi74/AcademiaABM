namespace Escritorio
{
    using System.Net;
    using System.Windows.Forms;
    using System.Collections.Generic;

    using Entidades;
    using Negocio;

    public partial class Grilla : Form
    {
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

        public Grilla()
        {
            InitializeComponent();
        }

        public IEnumerable<T> LeerEntidades<T>()
        {
            try
            {
                if (typeof(T) == typeof(Comision))
                {
                    this.listadoComisiones = ComisionNegocio.GetAll();
                    entidadListada = "Comision";
                    return (IEnumerable<T>) this.listadoComisiones.Result;
                }
                else if (typeof(T) == typeof(Curso))
                {
                    this.listadoCursos = CursoNegocio.GetAll();
                    entidadListada = "Curso";
                    return (IEnumerable<T>) this.listadoCursos.Result;
                }
                else if (typeof(T) == typeof(Docente_Curso))
                {
                    this.listadoDictados = DictadoNegocio.GetAll();
                    entidadListada = "Dictado";
                    return (IEnumerable<T>) this.listadoDictados.Result;
                }
                else if (typeof(T) == typeof(Especialidad))
                {
                    this.listadoEspecialidades = EspecialidadNegocio.GetAll();
                    entidadListada = "Especialidad";
                    return (IEnumerable<T>) this.listadoEspecialidades.Result;
                }
                else if (typeof(T) == typeof(Alumno_Inscripcion))
                {
                    this.listadoInscripciones = InscripcionNegocio.GetAll();
                    entidadListada = "Inscripcion";
                    return (IEnumerable<T>) this.listadoInscripciones.Result;
                }
                else if (typeof(T) == typeof(Materia))
                {
                    this.listadoMaterias = MateriaNegocio.GetAll();
                    entidadListada = "Materia";
                    return (IEnumerable<T>) this.listadoMaterias.Result;
                }
                else if (typeof(T) == typeof(Persona))
                {
                    this.listadoPersonas = PersonaNegocio.GetAll();
                    entidadListada = "Persona";
                    return (IEnumerable<T>) this.listadoPersonas.Result;
                }
                else if (typeof(T) == typeof(Plan))
                {
                    this.listadoPlanes = PlanNegocio.GetAll();
                    entidadListada = "Plan";
                    return (IEnumerable<T>) this.listadoPlanes.Result;
                }
                else if (typeof(T) == typeof(Usuario))
                {
                    this.listadoUsuarios = UsuarioNegocio.GetAll();
                    entidadListada = "Usuario";
                    return (IEnumerable<T>) this.listadoUsuarios.Result;
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

                if (planes != null)
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
                    entidadListada = "";
                }
            }
            else if (entidadListada == "Curso")
            {
                Task<IEnumerable<Comision>> task1 = new Task<IEnumerable<Comision>>(LeerEntidades<Comision>);
                task1.Start();
                IEnumerable<Comision> comisiones = await task1;

                if (comisiones != null)
                {
                    Task<IEnumerable<Materia>> task2 = new Task<IEnumerable<Materia>>(LeerEntidades<Materia>);
                    task2.Start();
                    IEnumerable<Materia> materias = await task2;

                    if (materias != null)
                    {
                        List<(int Id, string Descripcion)> opcionesComision = comisiones.Select(comision => (comision.Id_comision, comision.Desc_comision)).ToList();
                        List<(int Id, string Descripcion)> opcionesMateria = materias.Select(materia => (materia.Id_materia, materia.Desc_materia)).ToList();

                        CursoUI nuevoCurso = new CursoUI(opcionesComision, opcionesMateria);
                        if (nuevoCurso.ShowDialog(this) == DialogResult.OK)
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

                if (docentes != null)
                {
                    Task<IEnumerable<Curso>> task2 = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                    task2.Start();
                    IEnumerable<Curso> cursos = await task2;

                    if (cursos != null)
                    {
                        List<(int Id, string ApellidoYNombre)> opcionesDocente = docentes.Where(docente => docente.Tipo_persona == 1)
                                                                                         .Select(docente => (docente.Id_persona, docente.Apellido + ", " + docente.Nombre)).ToList();

                        List<(int Id, string MateriaYComision)> opcionesCurso = cursos.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                        DictadoUI nuevoDictado = new DictadoUI(opcionesDocente, opcionesCurso);
                        if (nuevoDictado.ShowDialog(this) == DialogResult.OK)
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

                if (alumnos != null)
                {
                    Task<IEnumerable<Curso>> task2 = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                    task2.Start();
                    IEnumerable<Curso> cursos = await task2;

                    if (cursos != null)
                    {
                        List<(int Id, string ApellidoYNombre)> opcionesAlumno = alumnos.Where(alumno => alumno.Tipo_persona == 0)
                                                                                       .Select(alumno => (alumno.Id_persona, alumno.Apellido + ", " + alumno.Nombre)).ToList();

                        List<(int Id, string MateriaYComision)> opcionesCurso = cursos.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                        InscripcionUI nuevaInscripcion = new InscripcionUI(opcionesAlumno, opcionesCurso);

                        var result = nuevaInscripcion.ShowDialog(this);
                        if (result == DialogResult.OK)
                        {
                            OperacionExitosa operacionExitosa = new OperacionExitosa();
                            operacionExitosa.ShowDialog(this);

                        } else if (result == DialogResult.Abort)
                        {
                            ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                            errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "El curso no tiene m�s cupos disponibles");
                            errorBD.ShowDialog(this);
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

                if (planes != null)
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
            }
            else if (entidadListada == "Persona")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                if (planes != null)
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
            }
            else if (entidadListada == "Plan")
            {
                Task<IEnumerable<Especialidad>> task = new Task<IEnumerable<Especialidad>>(LeerEntidades<Especialidad>);
                task.Start();
                IEnumerable<Especialidad> especialidades = await task;

                if (especialidades != null)
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
            }
            else if (entidadListada == "Usuario")
            {
                Task<IEnumerable<Persona>> task = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
                task.Start();
                IEnumerable<Persona> personas = await task;

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
        }

        private async void tsbEditar_Click(object sender, EventArgs e)
        {
            if (entidadListada == "Comision")
            {
                Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
                task.Start();
                IEnumerable<Plan> planes = await task;

                if (planes != null)
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    ComisionUI editarComision = new ComisionUI(opcionesPlan, listadoComisiones.Result.ToList()[filaSeleccionada]);

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

                if (comisiones != null)
                {
                    Task<IEnumerable<Materia>> task2 = new Task<IEnumerable<Materia>>(LeerEntidades<Materia>);
                    task2.Start();
                    IEnumerable<Materia> materias = await task2;

                    if (materias != null)
                    {
                        List<(int Id, string Descripcion)> opcionesComision = comisiones.Select(comision => (comision.Id_comision, comision.Desc_comision)).ToList();
                        List<(int Id, string Descripcion)> opcionesMateria = materias.Select(materia => (materia.Id_materia, materia.Desc_materia)).ToList();

                        int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                        CursoUI editarCurso = new CursoUI(opcionesComision, opcionesMateria, listadoCursos.Result.ToList()[filaSeleccionada]);

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

                if (docentes != null)
                {
                    Task<IEnumerable<Curso>> task2 = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                    task2.Start();
                    IEnumerable<Curso> cursos = await task2;

                    if (cursos != null)
                    {
                        List<(int Id, string ApellidoYNombre)> opcionesDocente = docentes.Where(docente => docente.Tipo_persona == 1)
                                                                                         .Select(docente => (docente.Id_persona, docente.Apellido + ", " + docente.Nombre)).ToList();

                        List<(int Id, string MateriaYComision)> opcionesCurso = cursos.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                        int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                        DictadoUI editarDictado = new DictadoUI(opcionesDocente, opcionesCurso, listadoDictados.Result.ToList()[filaSeleccionada]);

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

                EspecialidadUI editarEspecialidad = new EspecialidadUI(listadoEspecialidades.Result.ToList()[filaSeleccionada]);

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

                if (alumnos != null)
                {
                    Task<IEnumerable<Curso>> task2 = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
                    task2.Start();
                    IEnumerable<Curso> cursos = await task2;

                    if (cursos != null)
                    {
                        List<(int Id, string ApellidoYNombre)> opcionesAlumno = alumnos.Where(alumno => alumno.Tipo_persona == 0)
                                                                                       .Select(alumno => (alumno.Id_persona, alumno.Apellido + ", " + alumno.Nombre)).ToList();

                        List<(int Id, string MateriaYComision)> opcionesCurso = cursos.Select(curso => (curso.Id_curso, curso.Materia.Desc_materia + " - " + curso.Comision.Desc_comision)).ToList();

                        int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                        InscripcionUI editarInscripcion = new InscripcionUI(opcionesAlumno, opcionesCurso, listadoInscripciones.Result.ToList()[filaSeleccionada]);

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

                if (planes != null)
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    MateriaUI editarMateria = new MateriaUI(opcionesPlan, listadoMaterias.Result.ToList()[filaSeleccionada]);

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

                if (planes != null)
                {
                    List<(int Id, string Descripcion)> opcionesPlan = planes.Select(plan => (plan.Id_plan, plan.Desc_plan + " - " + plan.Especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    PersonaUI editarPersona = new PersonaUI(opcionesPlan, listadoPersonas.Result.ToList()[filaSeleccionada]);

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

                if (especialidades != null)
                {
                    List<(int Id, string Descripcion)> opcionesEspecialidad = especialidades.Select(especialidad => (especialidad.Id_especialidad, especialidad.Desc_especialidad)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    PlanUI editarPlan = new PlanUI(opcionesEspecialidad, listadoPlanes.Result.ToList()[filaSeleccionada]);

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

                if (personas != null)
                {
                    List<(int Id, string ApellidoYNombre)> opcionesPersona = personas.Select(persona => (persona.Id_persona, persona.Apellido + ", " + persona.Nombre)).ToList();

                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    UsuarioUI editarUsuario = new UsuarioUI(opcionesPersona, listadoUsuarios.Result.ToList()[filaSeleccionada]);

                    if (editarUsuario.ShowDialog(this) == DialogResult.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                    }
                    btnMostrarUsuarios_Click(sender, e);
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

                    var response = await ComisionNegocio.Delete(listadoComisiones.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);
                        
                        btnMostrarComisiones_Click(sender, e);

                    } else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La comisi�n tiene cursos asociados");
                        errorBD.ShowDialog(this);
                    }

                }
            }
            else if (entidadListada == "Curso")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await CursoNegocio.Delete(listadoCursos.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarCursos_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "El curso tiene inscripciones y/o dictados asociados");
                        errorBD.ShowDialog(this);
                    }
                }
            }
            else if (entidadListada == "Dictado")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await DictadoNegocio.Delete(listadoDictados.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarDictados_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La operaci�n no se ha podido llevar a cabo");
                        errorBD.ShowDialog(this);
                    }
                }
            }
            else if (entidadListada == "Especialidad")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await EspecialidadNegocio.Delete(listadoEspecialidades.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarEspecialidades_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La especialidad tiene planes asociados");
                        errorBD.ShowDialog(this);
                    }
                }
            }
            else if (entidadListada == "Inscripcion")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await InscripcionNegocio.Delete(listadoInscripciones.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarInscripciones_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La operaci�n no se ha podido llevar a cabo");
                        errorBD.ShowDialog(this);
                    }
                }
            }
            else if (entidadListada == "Materia")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await MateriaNegocio.Delete(listadoMaterias.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarMaterias_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La materia tiene cursos asociados");
                        errorBD.ShowDialog(this);
                    }
                }
            }
            else if (entidadListada == "Persona")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await PersonaNegocio.Delete(listadoPersonas.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarPersonas_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La persona tiene dictados, inscripciones y/o usuarios asociados");
                        errorBD.ShowDialog(this);
                    }
                }
            }
            else if (entidadListada == "Plan")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await PlanNegocio.Delete(listadoPlanes.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarPlanes_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "El plan tiene comisiones, materias y/o personas asociadas");
                        errorBD.ShowDialog(this);
                    }
                }
            }
            else if (entidadListada == "Usuario")
            {
                ConfirmarOperacion confirmarOperacion = new ConfirmarOperacion();
                if (confirmarOperacion.ShowDialog(this) == DialogResult.OK)
                {
                    int filaSeleccionada = dgvSysacad.SelectedRows[0].Index;

                    var response = await UsuarioNegocio.Delete(listadoUsuarios.Result.ToList()[filaSeleccionada]);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        OperacionExitosa operacionExitosa = new OperacionExitosa();
                        operacionExitosa.ShowDialog(this);

                        btnMostrarUsuarios_Click(sender, e);

                    }
                    else
                    {
                        ErrorBaseDeDatos errorBD = new ErrorBaseDeDatos();
                        errorBD.ErrorEliminacionLabel.Text = errorBD.ErrorEliminacionLabel.Text.Replace("${error}", "La operaci�n no se ha podido llevar a cabo");
                        errorBD.ShowDialog(this);
                    }
                }
            }
        }

        private async void btnMostrarComisiones_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Comision>> task = new Task<IEnumerable<Comision>>(LeerEntidades<Comision>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private async void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Curso>> task = new Task<IEnumerable<Curso>>(LeerEntidades<Curso>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private async void btnMostrarDictados_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Docente_Curso>> task = new Task<IEnumerable<Docente_Curso>>(LeerEntidades<Docente_Curso>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private async void btnMostrarEspecialidades_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Especialidad>> task = new Task<IEnumerable<Especialidad>>(LeerEntidades<Especialidad>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }
        
        private async void btnMostrarInscripciones_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Alumno_Inscripcion>> task = new Task<IEnumerable<Alumno_Inscripcion>>(LeerEntidades<Alumno_Inscripcion>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private async void btnMostrarMaterias_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Materia>> task = new Task<IEnumerable<Materia>>(LeerEntidades<Materia>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private async void btnMostrarPersonas_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Persona>> task = new Task<IEnumerable<Persona>>(LeerEntidades<Persona>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private async void btnMostrarPlanes_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Plan>> task = new Task<IEnumerable<Plan>>(LeerEntidades<Plan>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private async void btnMostrarUsuarios_Click(object sender, EventArgs e)
        {
            Task<IEnumerable<Usuario>> task = new Task<IEnumerable<Usuario>>(LeerEntidades<Usuario>);
            task.Start();

            dgvSysacad.DataSource = await task;
            SeleccionarPrimeraFila();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}