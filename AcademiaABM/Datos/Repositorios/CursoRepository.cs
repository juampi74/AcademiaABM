namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class CursoRepository
    {
        private readonly UniversidadContext _context;

        public CursoRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Curso> ObtenerTodosLosCursos()
        {
            return _context.Cursos.ToList();

        }

        public Curso ObtenerCursoPorId(int id)
        {
            return _context.Cursos.Find(id);
        }

        public void CrearCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            _context.SaveChanges();
        }

        public void ActualizarCurso(Curso curso)
        {
            var cursoExistente = _context.Cursos.Find(curso.Id_curso);
            if (cursoExistente != null)
            {
                cursoExistente.Id_comision = curso.Id_comision;
                cursoExistente.Anio_calendario = curso.Anio_calendario;
                _context.SaveChanges();
            }
        }

        public void EliminarCurso(int id)
        {
            var curso = _context.Cursos.Find(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                _context.SaveChanges();
            }
        }

        public List<Curso> OrdenarCursosAscendente()
        {
            return _context.Cursos.OrderBy(a => a.Anio_calendario).ThenBy(a => a.Cupo).ToList();
        }

        public List<Curso> OrdenarCursosDescendente()
        {
            return _context.Cursos.OrderByDescending(a => a.Anio_calendario).ThenByDescending(a => a.Cupo).ToList();
        }
    }
}

