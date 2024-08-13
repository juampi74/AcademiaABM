namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class PersonaRepository
    {
        private readonly UniversidadContext _context;

        public PersonaRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            return _context.Personas.ToList();
        }

        public Persona ObtenerPersonaPorId(int id)
        {
            return _context.Personas.Find(id);
        }

        public void CrearPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void ActualizarPersona(Persona persona)
        {
            var personaExistente = _context.Personas.Find(persona.Id_persona);
            if (personaExistente != null)
            {
                personaExistente.Nombre = persona.Nombre;
                personaExistente.Apellido = persona.Apellido;
                personaExistente.Direccion = persona.Direccion;
                personaExistente.Email = persona.Email;
                personaExistente.Telefono = persona.Telefono;
                personaExistente.Fecha_nac = persona.Fecha_nac;
                personaExistente.Legajo = persona.Legajo;
                personaExistente.Tipo_persona = persona.Tipo_persona;
                personaExistente.Id_plan = persona.Id_plan;

                _context.SaveChanges();
            }
        }

        public void EliminarPersona(int id)
        {
            var persona = _context.Personas.Find(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }

        public List<Persona> OrdenarPersonasAscendente()
        {
            return _context.Personas.OrderBy(per => per.Apellido).ThenBy(per => per.Nombre).ToList();
        }

        public List<Persona> OrdenarPersonasDescendente()
        {
            return _context.Personas.OrderByDescending(per => per.Apellido).ThenByDescending(per => per.Nombre).ToList();
        }
    }
}
