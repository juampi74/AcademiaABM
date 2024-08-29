namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class EspecialidadService
    {
        private readonly EspecialidadRepository _especialidadRepository;

        public EspecialidadService()
        {
            _especialidadRepository = new EspecialidadRepository();
        }

        public List<Especialidad> ObtenerTodasLasEspecialidades()
        {
            return _especialidadRepository.ObtenerTodasLasEspecialidades();
        }

        public Especialidad ObtenerEspecialidadPorId(int id)
        {
            return _especialidadRepository.ObtenerEspecialidadPorId(id);
        }

        public void CrearEspecialidad(Especialidad especialidad)
        {
            _especialidadRepository.CrearEspecialidad(especialidad);
        }

        public void ActualizarEspecialidad(Especialidad especialidad)
        {
            _especialidadRepository.ActualizarEspecialidad(especialidad);
        }

        public void EliminarEspecialidad(int id)
        {
            _especialidadRepository.EliminarEspecialidad(id);
        }

        public List<Especialidad> OrdenarEspecialidadesAscendente()
        {
            return _especialidadRepository.OrdenarEspecialidadesAscendente();
        }

        public List<Especialidad> OrdenarEspecialidadesDescendente()
        {
            return _especialidadRepository.OrdenarEspecialidadesDescendente();
        }
    }
}

