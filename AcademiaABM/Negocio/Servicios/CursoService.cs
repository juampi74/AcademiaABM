namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class CursoService
    {
        private readonly CursoRepository _cursoRepository;

        public CursoService()
        {
            _cursoRepository = new CursoRepository();
        }

        public List<Curso> ObtenerTodosLosCursos()
        {
            return _cursoRepository.ObtenerTodosLosCursos();
        }

        public Curso ObtenerCursoPorId(int id)
        {
            return _cursoRepository.ObtenerCursoPorId(id);
        }

        public void CrearCurso(Curso curso)
        {
            _cursoRepository.CrearCurso(curso);
        }

        public void ActualizarCurso(Curso curso)
        {
            _cursoRepository.ActualizarCurso(curso);
        }

        public void EliminarCurso(int id)
        {
            _cursoRepository.EliminarCurso(id);
        }

        public List<Curso> OrdenarCursosAscendente()
        {
            return _cursoRepository.OrdenarCursosAscendente();
        }

        public List<Curso> OrdenarCursosDescendente()
        {
            return _cursoRepository.OrdenarCursosDescendente();
        }
    }
}

