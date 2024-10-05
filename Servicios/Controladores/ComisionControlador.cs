namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class ComisionController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public ComisionController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetComision")]
        public ActionResult<IEnumerable<Comision>> GetAll()
        {
            try
            {
                return _context.Comisiones
                    .Include(com => com.Plan)
                        .ThenInclude(plan => plan.Especialidad)
                    .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Comision> GetById(int id)
        {
            try
            {
                var Comision = _context.Comisiones.Find(id);

                if (Comision == null)
                {
                    return NotFound();
                }

                return Comision;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost]
        public ActionResult<Comision> Create(ComisionDTO comisionDTO)
        {
            try
            {
                Comision nuevaComision = new Comision(comisionDTO.Desc_comision, comisionDTO.Anio_especialidad, comisionDTO.Id_plan);

                _context.Comisiones.Add(nuevaComision);
                _context.SaveChanges();

                return CreatedAtAction("GetById", new { id = nuevaComision.Id_comision }, nuevaComision);

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
        public ActionResult<Comision> Update(int id, [FromBody] ComisionDTO comisionDTO)
        {
            try
            {
                var Comision = _context.Comisiones.Find(id);

                if (Comision == null)
                {
                    return NotFound();
                }

                Comision.Desc_comision = comisionDTO.Desc_comision;
                Comision.Anio_especialidad = comisionDTO.Anio_especialidad;
                Comision.Id_plan = comisionDTO.Id_plan;

                _context.Entry(Comision).State = EntityState.Modified;
                _context.SaveChanges();

                return Comision;

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
        public ActionResult<Comision> Delete(int id)
        {
            try
            {
                var Comision = _context.Comisiones.Find(id);
                if (Comision == null)
                {
                    return NotFound();
                }

                _context.Comisiones.Remove(Comision);
                _context.SaveChanges();

                return Comision;
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