namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public PersonaController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetPersona")]
        public ActionResult<IEnumerable<Persona>> GetAll()
        {
            return _context.Personas
                .Include(per => per.Plan)
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> GetById(int id)
        {
            var Persona = _context.Personas.Find(id);

            if (Persona == null)
            {
                return NotFound();
            }

            return Persona;
        }

        [HttpPost]
        public ActionResult<Persona> Create(PersonaDTO personaDTO)
        {
            Persona nuevaPersona = new Persona(personaDTO.Nombre, personaDTO.Apellido, personaDTO.Direccion, personaDTO.Email, personaDTO.Telefono, personaDTO.Fecha_nac.Date, personaDTO.Legajo, personaDTO.Tipo_persona, personaDTO.Id_plan);

            _context.Personas.Add(nuevaPersona);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevaPersona.Id_persona }, nuevaPersona);
        }

        [HttpPatch("{id}")]
        public ActionResult<Persona> Update(int id, [FromBody] PersonaDTO personaDTO)
        {
            var Persona = _context.Personas.Find(id);

            if (Persona == null)
            {
                return NotFound();
            }

            Persona.Nombre = personaDTO.Nombre;
            Persona.Apellido = personaDTO.Apellido;
            Persona.Direccion = personaDTO.Direccion;
            Persona.Email = personaDTO.Email;
            Persona.Telefono = personaDTO.Telefono;
            Persona.Fecha_nac = personaDTO.Fecha_nac.Date;
            Persona.Legajo = personaDTO.Legajo;
            Persona.Tipo_persona = personaDTO.Tipo_persona;
            Persona.Id_plan = personaDTO.Id_plan;

            _context.Entry(Persona).State = EntityState.Modified;
            _context.SaveChanges();

            return Persona;
        }


        [HttpDelete("{id}")]
        public ActionResult<Persona> Delete(int id)
        {
            var Persona = _context.Personas.Find(id);
            if (Persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(Persona);
            _context.SaveChanges();

            return Persona;
        }

    }
}