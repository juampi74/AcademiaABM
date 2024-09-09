namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public EspecialidadController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetEspecialidad")]
        public ActionResult<IEnumerable<Especialidad>> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetById(int id)
        {
            var Especialidad = _context.Especialidades.Find(id);

            if (Especialidad == null)
            {
                return NotFound();
            }

            return Especialidad;
        }

        [HttpPost]
        public ActionResult<Especialidad> Create(EspecialidadDTO especialidadDTO)
        {
            var nuevaEspecialidad = new Especialidad(especialidadDTO.Desc_especialidad);

            _context.Especialidades.Add(nuevaEspecialidad);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevaEspecialidad.Id_especialidad }, nuevaEspecialidad);
        }

        [HttpPatch("{id}")]
        public ActionResult<Especialidad> Update(int id, [FromBody] EspecialidadDTO especialidadDTO)
        {
            var Especialidad = _context.Especialidades.Find(id);

            if (Especialidad == null)
            {
                return NotFound();
            }

            Especialidad.Desc_especialidad = especialidadDTO.Desc_especialidad;

            _context.Entry(Especialidad).State = EntityState.Modified;
            _context.SaveChanges();

            return Especialidad;
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Especialidad> Delete(int id)
        {
            var Especialidad = _context.Especialidades.Find(id);
            if (Especialidad == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(Especialidad);
            _context.SaveChanges();

            return Especialidad;
        }

    }
}