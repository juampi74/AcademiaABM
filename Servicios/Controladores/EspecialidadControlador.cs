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
            try
            {
                return _context.Especialidades.ToList();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetById(int id)
        {
            try
            {
                var Especialidad = _context.Especialidades.Find(id);

                if (Especialidad == null)
                {
                    return NotFound();
                }

                return Especialidad;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost]
        public ActionResult<Especialidad> Create(EspecialidadDTO especialidadDTO)
        {
            try
            {
                Especialidad nuevaEspecialidad = new Especialidad(especialidadDTO.Desc_especialidad);

                _context.Especialidades.Add(nuevaEspecialidad);
                _context.SaveChanges();

                return CreatedAtAction("GetById", new { id = nuevaEspecialidad.Id_especialidad }, nuevaEspecialidad);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<Especialidad> Update(int id, [FromBody] EspecialidadDTO especialidadDTO)
        {
            try
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
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Especialidad> Delete(int id)
        {
            try
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
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}