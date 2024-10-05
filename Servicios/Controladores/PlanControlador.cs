namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public PlanController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetPlan")]
        public ActionResult<IEnumerable<Plan>> GetAll()
        {
            try
            {
                return _context.Planes
                    .Include(plan => plan.Especialidad)
                    .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Plan> GetById(int id)
        {
            try
            {
                var Plan = _context.Planes.Find(id);

                if (Plan == null)
                {
                    return NotFound();
                }

                return Plan;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost]
        public ActionResult<Plan> Create(PlanDTO planDTO)
        {
            try
            {
                Plan nuevoPlan = new Plan(planDTO.Desc_plan, planDTO.Id_especialidad);

                _context.Planes.Add(nuevoPlan);
                _context.SaveChanges();

                return CreatedAtAction("GetById", new { id = nuevoPlan.Id_plan }, nuevoPlan);

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
        public ActionResult<Plan> Update(int id, [FromBody] PlanDTO planDTO)
        {
            try
            {
                var Plan = _context.Planes.Find(id);

                if (Plan == null)
                {
                    return NotFound();
                }

                Plan.Desc_plan = planDTO.Desc_plan;
                Plan.Id_especialidad = planDTO.Id_especialidad;

                _context.Entry(Plan).State = EntityState.Modified;
                _context.SaveChanges();

                return Plan;

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
        public ActionResult<Plan> Delete(int id)
        {
            try
            {
                var Plan = _context.Planes.Find(id);
                if (Plan == null)
                {
                    return NotFound();
                }

                _context.Planes.Remove(Plan);
                _context.SaveChanges();

                return Plan;
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