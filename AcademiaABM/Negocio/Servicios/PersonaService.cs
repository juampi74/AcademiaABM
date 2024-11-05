namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class PersonaService
    {
        private readonly PersonaRepository _personaRepository;

        public PersonaService()
        {
            _personaRepository = new PersonaRepository();
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            return _personaRepository.ObtenerTodasLasPersonas();
        }

        public Persona ObtenerPersonaPorId(int id)
        {
            return _personaRepository.ObtenerPersonaPorId(id);
        }

        public void CrearPersona(Persona persona)
        {
            _personaRepository.CrearPersona(persona);
        }

        public void ActualizarPersona(Persona persona)
        {
            _personaRepository.ActualizarPersona(persona);
        }

        public void EliminarPersona(int id)
        {
            _personaRepository.EliminarPersona(id);
        }

        public List<Persona> OrdenarPersonasAscendente()
        {
            return _personaRepository.OrdenarPersonasAscendente();
        }

        public List<Persona> OrdenarPersonasDescendente()
        {
            return _personaRepository.OrdenarPersonasDescendente();
        }
    }
}
