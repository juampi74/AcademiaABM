namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class AlumnoRepository
    {
        private readonly UniversidadContext _context;

        public AlumnoRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Alumno> ObtenerTodosLosAlumnos()
        {
            return _context.Alumnos.ToList();
        }

        public Alumno ObtenerAlumnoPorId(int id)
        {
            return _context.Alumnos.Find(id);
        }

        public void CrearAlumno(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
        }

        public void ActualizarAlumno(Alumno alumno)
        {
            var alumnoExistente = _context.Alumnos.Find(alumno.Id);
            if (alumnoExistente != null)
            {
                alumnoExistente.Apellido = alumno.Apellido;
                alumnoExistente.Nombre = alumno.Nombre;
                alumnoExistente.Legajo = alumno.Legajo;
                alumnoExistente.Direccion = alumno.Direccion;
                alumnoExistente.Telefono = alumno.Telefono;
                _context.SaveChanges();
            }
        }

        public void EliminarAlumno(int id)
        {
            var alumno = _context.Alumnos.Find(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
                _context.SaveChanges();
            }
        }

        public List<Alumno> OrdenarAlumnosAscendente()
        {
            return _context.Alumnos.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre).ToList();
        }

        public List<Alumno> OrdenarAlumnosDescendente()
        {
            return _context.Alumnos.OrderByDescending(a => a.Apellido).ThenByDescending(a => a.Nombre).ToList();
        }
    }
}
