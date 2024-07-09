namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class AlumnoService
    {
        private readonly AlumnoRepository _alumnoRepository;

        public AlumnoService()
        {
            _alumnoRepository = new AlumnoRepository();
        }

        public List<Alumno> ObtenerTodosLosAlumnos()
        {
            return _alumnoRepository.ObtenerTodosLosAlumnos();
        }

        public Alumno ObtenerAlumnoPorId(int id)
        {
            return _alumnoRepository.ObtenerAlumnoPorId(id);
        }

        public void CrearAlumno(Alumno alumno)
        {
            _alumnoRepository.CrearAlumno(alumno);
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            _alumnoRepository.ActualizarAlumno(alumno);
        }

        public void EliminarAlumno(int id)
        {
            _alumnoRepository.EliminarAlumno(id);
        }

        public List<Alumno> OrdenarAlumnosAscendente()
        {
            return _alumnoRepository.OrdenarAlumnosAscendente();
        }

        public List<Alumno> OrdenarAlumnosDescendente()
        {
            return _alumnoRepository.OrdenarAlumnosDescendente();
        }
    }
}
