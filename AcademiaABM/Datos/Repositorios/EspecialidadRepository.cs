namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class EspecialidadRepository
    {
        private readonly UniversidadContext _context;

        public EspecialidadRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Especialidad> ObtenerTodasLasEspecialidades()
        {
            return _context.Especialidades.ToList();
        }

        public Especialidad ObtenerEspecialidadPorId(int id)
        {
            return _context.Especialidades.Find(id);
        }

        public void CrearEspecialidad(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            _context.SaveChanges();
        }

        public void ActualizarEspecialidad(Especialidad especialidad)
        {
            var especialidadExistente = _context.Especialidades.Find(especialidad.Id_especialidad);
            if (especialidadExistente != null)
            {
                especialidadExistente.Desc_especialidad = especialidad.Desc_especialidad;
                _context.SaveChanges();
            }
        }

        public void EliminarEspecialidad(int id)
        {
            var especialidad = _context.Especialidades.Find(id);
            if (especialidad != null)
            {
                _context.Especialidades.Remove(especialidad);
                _context.SaveChanges();
            }
        }

        public List<Especialidad> OrdenarEspecialidadesAscendente()
        {
            return _context.Especialidades.OrderBy(a => a.Desc_especialidad).ToList();
        }

        public List<Especialidad> OrdenarEspecialidadesDescendente()
        {
            return _context.Especialidades.OrderByDescending(a => a.Desc_especialidad).ToList();
        }
    }
}
